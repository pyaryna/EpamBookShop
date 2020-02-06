using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.BLL.Interfaces;
using BookShop.BLL.Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(UserRegistrationRequest registrationRequest)
        {
            return Ok(await _authService.RegisterAsync(registrationRequest));
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserLoginRequest loginRequest)
        {
            return Ok(await _authService.LoginAsync(loginRequest));
        }

        //[HttpPost("refresh")]
        //public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest)
        //{
        //    return Ok(await _authService.RefreshTokenAsync(refreshTokenRequest));
        //}
    }
}