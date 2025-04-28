using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Models.UserMessages;
using PharmaCare.DAL.Models.UserNotifications;
namespace PharmaCare.DAL.Models
{
    public class Customer : UserBase
    {
        // Message need to convert to THP Relation
        public virtual ICollection<MessagesCustomer>? Messages { get; set; }
        public virtual Chat? Chat { get; set; }
        public virtual ICollection<Purchase>? Purchases { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual CustomerAddress? Address { get; set; }
        public virtual ICollection<CustomerNotification>? CustomerNotifications { get; set; }    
    }
}
