using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.NotificationRepository
{

    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);



    }
}
