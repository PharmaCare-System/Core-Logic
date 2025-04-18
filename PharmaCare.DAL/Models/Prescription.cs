using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public DateTime UploadDate { get; set; }
        public PrescriptionStatus Status { get; set; }

        // relation

        // Customer upload Prescription
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // pharmcist who reviewd the prescription
        public int PharamcistId { get; set; }
        public virtual Pharmacist? Pharmacist { get; set; }
    }
    
}
