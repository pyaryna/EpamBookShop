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
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksInfo()
        {
            return Ok(await _bookService.GetAllBooksInfoAsync());
        }

        [HttpGet("{id}")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _bookService.GetOneBookInfoAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromForm]AddBookDto addBook)
        {
            return Ok(await _bookService.AddBookAsync(addBook));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromForm]UpdateBookDto updateBook)
        {
            return Ok(await _bookService.UpdateBookAsync(id, updateBook));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBookById(int id)
            {
            await _bookService.RemoveBookByIdAsync(id);
            return Ok();
        }
    }
}