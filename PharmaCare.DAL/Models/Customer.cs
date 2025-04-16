using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Models
{
    
    public class Customer
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual CustomerAddress CustomerAddress { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual Chat Chat { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
    
}
