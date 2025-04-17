using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models.Address;

namespace PharmaCare.DAL.Models
{
    public class Pharmacist : UserBase
    {
        public DateTime HireDate { get; set; }

        int PharmacyId { get; set; }
        public virtual Pharamcy Pharamcy { get; set; }

        int AddressId { get; set; }
        public virtual Address? Address { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Messages>? Messages { get; set; }
    }
}
