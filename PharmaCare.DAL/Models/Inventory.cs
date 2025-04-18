using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserNotifications;

namespace PharmaCare.DAL.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location  { get; set; }
        public int QuantityStock { get; set; }
        public int PharmacyId { get; set; }
        public Pharmacy? Pharmacy { get; set; }

        public ICollection<Notifacation>? Notifacations { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
