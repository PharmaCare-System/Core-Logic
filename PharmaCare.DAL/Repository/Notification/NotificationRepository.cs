using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notification.Dal;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCareNot.DAL
{
    public class NotificationRepository:GenericRepository<Notifacation>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notifacation>> GetUnreadNotificationsAsync(int userId)
        {
            return await _DbSet
                .Where(n => n.RecieverId == userId && !n.IsRead)
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _DbSet.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }

    }
   
}
