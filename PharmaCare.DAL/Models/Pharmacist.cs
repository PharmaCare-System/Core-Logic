namespace PharmaCare.DAL.Models
{
    public class Pharmacist
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
