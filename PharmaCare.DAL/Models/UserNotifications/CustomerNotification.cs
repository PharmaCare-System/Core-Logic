namespace PharmaCare.DAL.Models.UserNotifications
{
    public class CustomerNotification : Notification
    {
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
