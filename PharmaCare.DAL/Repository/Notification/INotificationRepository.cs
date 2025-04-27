using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace Notification.Dal
{
    public interface INotificationRepository : IGenericRepository<Notifacation>
    {
        Task<IEnumerable<Notifacation>> GetUnreadNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);



    }
}
