using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models.ProductRel;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Models
{
    public class Order
    {
        public int Id;
        public OrderTypes OrderType { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatuses OrderStatus { get; set; }

        // Customer
        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        // Purchase
        public virtual Purchase? Purchase { get; set; }

        // M - N Relation with Product
        public virtual ICollection<Product>? Products { get; set; }
        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }

        //pharmacist
        public int? PharmacistId { get; set; }
        public Pharmacist? Pharmacist { get; set; }

        //Notification
        public virtual ICollection<Notification>? Notifications { get; set; }

        //pharmacy
        public int PharmacyId { get; set; }
        public Pharmacy? pharmacy{ get; set; }

        public virtual ICollection<ProductOrder>? OrderProducts { get; set; }
    }
}
