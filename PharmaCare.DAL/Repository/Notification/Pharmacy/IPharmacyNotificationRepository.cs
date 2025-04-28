using PharmaCare.DAL.Models.UserNotifications;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Notification.Pharmacy
{
    public interface IPharmacyNotificationRepository : IGenericRepository<PharmacyNotification>
    {
        Task<IEnumerable<PharmacyNotification>> GetUnreadPharmacyNotificationsAsync(int userId);
        Task MarkAsReadAsync(int notificationId);



    }
}
