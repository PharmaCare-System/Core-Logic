namespace PharmaCare.DAL.Models
{
    public class Product
    {
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
