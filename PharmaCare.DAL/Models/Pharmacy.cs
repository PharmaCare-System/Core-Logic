using PharmaCare.DAL.Models.UserNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int? MangerPharmacyId { get; set; }
        public ICollection<Purchase>? purchases { get; set; }
        public Inventory? inventory { get; set; }
        public Pharmacist? ManagerPharmacy { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Pharmacist>? Pharmacists { get; set; }
        public virtual ICollection<Chat>? Chats { get; set; }
        public virtual ICollection<PharmacyNotification>? PharmacyNotifications { get; set; }
    }
}
