namespace PharmaCare.DAL.Models.UserMessages
{
    public class MessagesPharmacist : Messages
    {
        public virtual Pharmacist? Pharmacist { get; set; }
    }

}
