using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int QuantityInStock { get; set; }
        public bool BulkAllowed { get; set; } = false;
        public bool PrescriptionRequired { get; set; } = true;
        public String BarCode { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }


        public int InventoryId { get; set; }
        public virtual Inventory? Inventory { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }

        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<CartProducts>?  CartProducts  { get; set; }
    }
}
