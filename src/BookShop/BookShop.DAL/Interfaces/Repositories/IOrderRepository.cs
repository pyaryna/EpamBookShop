using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        Task<Order> FindAsync(int id);
        Task<IEnumerable<Order>> GetUserOrdersAsync(string id);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
