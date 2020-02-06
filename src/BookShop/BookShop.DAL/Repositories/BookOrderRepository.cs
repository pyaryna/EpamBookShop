using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.Repositories
{
    public class BookOrderRepository : Repository<BookOrder, int>, IBookOrderRepository
    {
        public BookOrderRepository(PublishingHouseContext context) : base(context) { }
    }
}
