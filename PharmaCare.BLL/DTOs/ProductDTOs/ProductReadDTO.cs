using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.ProductDTOs
{
    public class ProductReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int QuantityInStock { get; set; }
        public String BarCode { get; set; }
        public string ImageURL { get; set; }

        public int InventoryId { get; set; }
    }
}
