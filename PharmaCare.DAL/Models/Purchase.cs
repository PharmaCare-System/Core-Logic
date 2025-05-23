using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models
{
    public class Purchase : BaseEntity
    {
        public float TotalCost { get; set; }
        public bool IsVendor { get; set; } = false; // if true, customerId = another pharmacyId
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime PurchaseDate { get; set; }
            
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int PharmacyId { get; set; }
        public virtual Pharmacy? Pharmacy { get; set; }

        public int PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
