using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Models.UserNotifications
{
    public class MessageNotification : Notifacation
    {
        public Messages Message { get; set; }
    }


}
