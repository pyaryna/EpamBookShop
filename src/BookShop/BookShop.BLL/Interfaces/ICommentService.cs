using BookShop.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllCommentsForBookAsync(int bookId);
        Task AddCommentAsync(AddCommentDto addComment);
        Task RemoveCommentByIdAsync(int id);
    }
}
