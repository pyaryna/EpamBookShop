using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
