using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.NotificationDTOs
{
    
    public class NotifacationAddDTO
    {

        public int UserId { get; set; }

        public UserType UserType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public Inventory? Inventory { get; set; }
        public Order? order { get; set; }
    }
}
