using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Notification.Customer
{
    public class CustomerNotificationRepository : GenericRepository<CustomerNotification>, ICustomerNotificationRepository
    {
        public CustomerNotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CustomerNotification>> GetUnreadCustomerNotificationsAsync(int userId)
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
