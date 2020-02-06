using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Task<Category> FindAsync(int key);
    }
}
