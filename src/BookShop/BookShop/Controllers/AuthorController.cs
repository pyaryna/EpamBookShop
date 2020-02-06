using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookShop.BLL.DTOs;
using BookShop.BLL.Interfaces;

namespace BookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorsInfo()
        {
            return Ok(await _authorService.GetAllAuthorsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromForm]AddAuthorDto addAuthor)
        {
            return Ok(await _authorService.AddAuthorAsync(addAuthor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAuthorById(int id)
        {
            await _authorService.RemoveAuthorByIdAsync(id);
            return Ok();
        }
    }
}