using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Models.UserNotifications
{
    public class MessageNotification : Notification
    {
        public Messages Message { get; set; }
    }
}
