using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Models
{
    public class Chat
    {
        public int Id { get; set; }

        // pharmacy and chat 1-N
        public int PharmacyId { get; set; }
        public virtual Pharmacy? Pharmacy { get; set; }
        // chat and messages 1-N
        public virtual ICollection<Messages>? Messages { get; set; }

        // customer has only one chat
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        // pharmacist can be in more than one chat
        public virtual ICollection<Pharmacist>? pharmacists { get; set; }
        public virtual ICollection<PharmacistChats>? pharmacistChats { get; set; }
    }
}
