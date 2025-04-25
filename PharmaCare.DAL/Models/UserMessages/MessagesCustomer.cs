namespace PharmaCare.DAL.Models.UserMessages
{
    public class MessagesCustomer : Messages
    {
        public virtual Customer? Customer { get; set; }
    }
}
