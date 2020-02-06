using BookShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL.Interfaces.Repositories
{
    public interface INotificationRepository : IRepository<Notification, int>
    {
        Task<Notification> FindAsync(int id);

        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
    }
}
