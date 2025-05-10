using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.DTOs.OrderDTOs
{
    public class ProductOrderDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
