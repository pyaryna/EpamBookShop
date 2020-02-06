using BookShop.DAL.Entities;
using BookShop.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.Repositories
{
    public class BookCategoryRepository : Repository<BookCategory, int>, IBookCategoryRepository
    {
        public BookCategoryRepository(PublishingHouseContext context) : base(context) { }
    }
}
