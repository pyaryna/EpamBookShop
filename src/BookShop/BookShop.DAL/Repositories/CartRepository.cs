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
    public class CartRepository : Repository<Cart, int>, ICartRepository
    {
        public CartRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Cart> FindAsync(int id)
        {
            return await Context.Carts
                .Include(c => c.Book)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Cart> FindAsync(int bookId, string customerId)
        {
            return await Context.Carts
                .Include(c => c.Book)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(d => d.BookId == bookId && d.CustomerId == customerId);
        }

        public async Task<IEnumerable<Cart>> GetUserCartsAsync(string id)
        {
            var carts = Context.Carts
                .Where(c => c.CustomerId == id)
                .Include(c => c.Book)
                .Include(c => c.Customer);                

            return await carts.ToListAsync();
        }
    }
}
