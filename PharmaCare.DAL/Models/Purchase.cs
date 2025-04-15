namespace PharmaCare.DAL.Models
{
    public class Purchase
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
    
}
