﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.Entities
{
    public class BookCategory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
