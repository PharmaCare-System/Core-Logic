using PharmaCare.DAL.Models.ProductRel;

namespace PharmaCare.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int QuantityinStock { get; set; }
        public bool BulkAllowed { get; set; } = false;

        public bool PrescriptionRequired { get; set; } = true;

        public  String BarCode { get; set; }

        public byte[]? Image { get; set; }


        public int InventoryId { get; set; }
        public virtual Inventory? Inventory { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }

        public virtual ICollection<ProductCategory>? ProductCategories  { get; set; }

        public virtual ICollection<Cart_Products>?  Cart_Products  { get; set; }






    }
}
