using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.BLL.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public BookPreviewDto Book { get; set; }
        public int Amount { get; set; }
    }
}
