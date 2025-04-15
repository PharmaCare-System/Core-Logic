namespace PharmaCare.DAL.Models
{
    public class Prescription
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
    
}
