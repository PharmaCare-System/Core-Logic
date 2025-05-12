using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Models.UserMessages;

namespace PharmaCare.DAL.Models
{
    public class Pharmacist : ApplicationUser
    {

        //---------
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int ManagerId { get; set; } 

        // relations
        public int? PharmacyId { get; set; }
        public virtual Pharmacy? Pharmacy { get; set; }
        public virtual Pharmacy? ManagedPharmacy { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        // HTP Relation
        public virtual ICollection<MessagesPharmacist>? Messages { get; set; }

        public virtual ICollection<Chat>? Chats { get; set; }
        public virtual ICollection<PharmacistChats>? PharmacistChats { get; set; }

        public virtual ICollection<Prescription>? Prescriptions { get; set; }
        public virtual PharmacistAddress? Address { get; set; }
    }
}