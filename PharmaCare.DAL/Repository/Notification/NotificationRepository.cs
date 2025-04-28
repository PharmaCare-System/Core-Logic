using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Repository.NotificationRepository;

namespace PharmaCareNot.DAL
{
    public class NotificationRepository:GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Notification>> GetUnreadNotificationsAsync(int userId)
        {
            return await _DbSet
                .Where(n => n.UserId == userId && !n.IsRead)
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
