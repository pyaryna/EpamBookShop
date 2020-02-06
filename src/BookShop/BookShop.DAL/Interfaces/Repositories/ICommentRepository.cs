using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        Task<Comment> FindAsync(int key);
        Task<IEnumerable<Comment>> GetAllCommentsByBookIdAsync(int bookId);
    }
}
