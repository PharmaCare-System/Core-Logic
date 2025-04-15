namespace PharmaCare.DAL.Models
{
    public class Review
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
    
}
