namespace PharmaCare.DAL.Models
{
    public class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderRefId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }
    }
}
