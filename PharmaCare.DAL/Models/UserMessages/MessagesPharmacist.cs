namespace PharmaCare.DAL.Models.UserMessages
{
    public class MessagesPharmacist : Messages
    {
        public int pharmacistId { get; set; }
        public virtual Pharmacist? Pharmacist { get; set; }
    }

}
