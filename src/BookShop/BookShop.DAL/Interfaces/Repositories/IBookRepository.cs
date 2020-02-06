using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<Book> FindAsync(int key);
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
