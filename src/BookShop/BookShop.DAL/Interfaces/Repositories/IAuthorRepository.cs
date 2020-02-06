using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface IAuthorRepository: IRepository<Author, int>
    {
        Task<Author> FindAsync(int key);
    }
}
