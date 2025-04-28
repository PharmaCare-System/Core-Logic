using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Models.UserNotifications
{
    public class PharmacyNotification : Notification
    {
        public int PharmacyId { get; set; } 
        public virtual Pharmacy? Pharmacy { get; set; }
    }
}
