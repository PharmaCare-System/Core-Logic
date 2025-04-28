using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Notification.Customer
{
    public interface ICustomerNotificationRepository : IGenericRepository<CustomerNotification>
    {
        Task<IEnumerable<CustomerNotification>> GetUnreadCustomerNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);



    }
}
