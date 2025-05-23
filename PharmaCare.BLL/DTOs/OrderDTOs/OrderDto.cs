using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;

namespace PharmaCare.BLL.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public OrderTypes OrderType { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatuses OrderStatus { get; set; }

        public int? CustomerId { get; set; }
        public int? PharmacistId { get; set; }
        public int? PharmacyId { get; set; }

        public List<ProductOrderDTO> OrderProducts { get; set; } = new();
    }

}
