namespace PharmaCare.DAL.Models
{
    public class Pharmacy
    {
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Pharmacist>? Pharmacists { get; set; }
        public virtual ICollection<Chat>? Chats { get; set; }

        public int PharmacistId { get; set; }
        public virtual Pharmacist? PharmacistManager {get; set;}

    }
}
