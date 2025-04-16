namespace PharmaCare.DAL.Models
{
    public class Notifications<T>
    {
        public int? SenderId { get; set; }
        public T? Sender { get; set; }
    }
}
