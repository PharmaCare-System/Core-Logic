namespace PharmaCare.DAL.Models.UserMessages
{
    public class MessagesCustomer : Messages
    {
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
