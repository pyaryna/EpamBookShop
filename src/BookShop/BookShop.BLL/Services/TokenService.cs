using BookShop.BLL.Interfaces;
using BookShop.BLL.Settings;
using BookShop.DAL;
using BookShop.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL.Services
{
    public class TokenService: ITokenService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManager<Customer> _userManager;
        private readonly JwtSettings _jwtSettings;

        public TokenService(
            IPublishingHouseUnitOfWork unitOfWork,
            IOptions<JwtSettings> jwtOptions,
            TokenValidationParameters tokenValidationParameters,
            UserManager<Customer> userManager)
        {
            _unitOfWork = unitOfWork;
            _tokenValidationParameters = tokenValidationParameters;
            _userManager = userManager;
            _jwtSettings = jwtOptions.Value;
        }


        public async Task<string> GenerateJwtToken(Customer user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            var userClaims = await _userManager.GetClaimsAsync(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, $"{Guid.NewGuid()}"),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(ClaimTypes.Role, userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "User"),
                        new Claim("id", $"{user.Id}")
                    }),
                Expires = DateTime.UtcNow.Add(_jwtSettings.JwtTokenLifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }       

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken) =>
            validatedToken is JwtSecurityToken jwtSecurityToken
            && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                
        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var notValidateLifetimeToken = _tokenValidationParameters.Clone();
            notValidateLifetimeToken.ValidateLifetime = false;

            var principal = tokenHandler.ValidateToken(token, notValidateLifetimeToken, out var securityToken);
            
            return principal;
        }
    }
}
