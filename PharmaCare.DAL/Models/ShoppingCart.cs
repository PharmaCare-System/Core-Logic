using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<Product>? Products { get; set; } 
        public virtual ICollection<CartProducts>? Cart_Products { get; set; }
    }
}
