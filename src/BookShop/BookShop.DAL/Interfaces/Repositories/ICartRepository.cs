using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface ICartRepository : IRepository<Cart, int>
    {
        Task<Cart> FindAsync(int id);
        Task<Cart> FindAsync(int bookId, string customerId);

        Task<IEnumerable<Cart>> GetUserCartsAsync(string id);
    }
}
