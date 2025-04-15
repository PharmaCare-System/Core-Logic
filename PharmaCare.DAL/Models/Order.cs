namespace PharmaCare.DAL.Models
{
    public class Order
    {
        public int Id;
        public string OrderType { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
