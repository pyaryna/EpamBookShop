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
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesInfo()
        {
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm]AddCategoryDto addCategory)
        {
            return Ok(await _categoryService.AddCategoryAsync(addCategory));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategoryById(int id)
        {
            await _categoryService.RemoveCategoryByIdAsync(id);
            return Ok();
        }
    }
}