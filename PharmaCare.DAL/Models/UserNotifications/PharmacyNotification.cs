using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Models.UserNotifications
{
    public class PharmacyNotification : Notification
    {
        public virtual Pharmacy? Pharmacy { get; set; }
    }
}
