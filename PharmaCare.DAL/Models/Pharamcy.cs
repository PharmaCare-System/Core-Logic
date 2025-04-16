namespace PharmaCare.DAL.Models
{
    public class Pharamcy
    {
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
