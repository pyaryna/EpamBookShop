using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(Customer user);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
