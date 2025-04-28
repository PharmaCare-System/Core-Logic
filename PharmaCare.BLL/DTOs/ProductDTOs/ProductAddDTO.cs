using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.ProductDTOs
{
    public class ProductAddDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int QuantityInStock { get; set; }
        public bool BulkAllowed { get; set; } = false;
        public bool PrescriptionRequired { get; set; } = true;
        public String BarCode { get; set; }
        public string ImageURL { get; set; }

        public int InventoryId { get; set; }
    }
}

