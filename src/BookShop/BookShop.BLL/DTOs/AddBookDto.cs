using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.BLL.DTOs
{
    public class AddBookDto
    { 
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public string Format { get; set; }
        public string Cover { get; set; }
        public int PagesAmount { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
