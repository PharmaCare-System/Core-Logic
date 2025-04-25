namespace PharmaCare.DAL.Models.UserNotifications
{
    public class OrderNotification : Notification
    {
        public Order Order { get; set; }
    }
}
