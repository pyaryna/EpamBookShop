using Microsoft.EntityFrameworkCore;
using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(PublishingHouseContext context) : base(context) { }

        public async Task<Category> FindAsync(int key)
        {
            return await Context.Set<Category>()
                .FirstOrDefaultAsync(x => x.Id.Equals(key));
        }
    }
}
