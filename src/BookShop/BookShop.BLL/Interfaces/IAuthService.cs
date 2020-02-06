using BookShop.BLL.Models.RequestModel;
using BookShop.BLL.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(UserRegistrationRequest registrationRequest);
        Task<AuthResponse> LoginAsync(UserLoginRequest loginRequest);
        //Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
    }
}
