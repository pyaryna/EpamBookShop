using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.Repositories
{
    public class BookAuthorRepository : Repository<BookAuthor, int>, IBookAuthorRepository
    {
        public BookAuthorRepository(PublishingHouseContext context) : base(context) { }
    }
}
