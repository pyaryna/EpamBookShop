using Microsoft.EntityFrameworkCore;
using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Repositories
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Order> FindAsync(int id)
        {
            return await Context.Orders
                .Include(o => o.Customer)
                .Include(o => o.BookOrders)
                .ThenInclude(bo => bo.Book)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(string id)
        {
            var orders = Context.Orders
                .Where(o => o.CustomerId == id)
                .Include(o => o.BookOrders)
                .ThenInclude(bo => bo.Book)
                .Include(c => c.Customer);
                

            return await orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var orders = Context.Orders
                .Include(o => o.BookOrders)
                .ThenInclude(bo => bo.Book)
                .Include(c => c.Customer);

            return await orders.ToListAsync();
        }
    }
}
