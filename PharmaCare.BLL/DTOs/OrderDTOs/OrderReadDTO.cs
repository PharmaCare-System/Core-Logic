using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.OrderDTOs
{
    public class OrderReadDTO
    {
        public int Id { get; set; }
        public OrderTypes OrderType { get; set; }
        public string DeliveryAddress { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatuses OrderStatus { get; set; }
        public List<ProductOrderAddDTO> OrderProducts { get; set; }


        public int? CustomerId { get; set; }
 
        public int? PharmacistId { get; set; }


        public int? PharmacyId { get; set; }

    }
}
