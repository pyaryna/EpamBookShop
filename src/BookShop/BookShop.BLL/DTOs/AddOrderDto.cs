using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.BLL.DTOs
{
    public class AddOrderDto
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Deliver { get; set; }
        public string DeliverAddress { get; set; }
        public DateTime DateTime { get; set; }
        public int TotalSum { get; set; }
        public List<CartDto> Carts { get; set; }        
    }
}
