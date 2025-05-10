using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models
{
    public class Prescription : BaseEntity
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public PrescriptionStatus Status { get; set; }
        public string ImageURL { get; set; }

        // Customer upload Prescription
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // Pharmacist who review the prescription
        public int? PharmacistId { get; set; }
        public  Pharmacist? Pharmacist { get; set; }
    }
}
