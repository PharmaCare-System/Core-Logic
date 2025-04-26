namespace PharmaCare.DAL.Models.UserNotifications
{
    public class CustomerNotification : Notification
    {
        public virtual Customer? Customer { get; set; }
    }
}
