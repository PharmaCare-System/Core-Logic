using System.ComponentModel.DataAnnotations;

namespace PharmaCare.DAL.Models.UserAddress
{
    public class PharmacistAddress : Address
    {
        public int? PharmacistId { get; set; }
        public virtual Pharmacist? Pharmacist { get; set; }
    }
}
