namespace PharmaCare.DAL.Models
{
    public class CustomerAddress
    {
        public int Id;
        public short streetNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
