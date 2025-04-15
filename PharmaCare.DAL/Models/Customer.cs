using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Models
{
    enum OrderTypes {
        Retail,
        Bulk
    }
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
        public CustomerAddress CustomerAddress { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public Chat Chat { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
    
}
