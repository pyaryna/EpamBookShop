using BookShop.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
        Task<AuthorDto> AddAuthorAsync(AddAuthorDto addAuthor);
        Task RemoveAuthorByIdAsync(int id);
    }
}
