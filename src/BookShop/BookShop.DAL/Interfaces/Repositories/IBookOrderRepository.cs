using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface IBookOrderRepository : IRepository<BookOrder, int>
    {
    }
}
