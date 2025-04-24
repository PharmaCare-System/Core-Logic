using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.DTOs.NotifaciionDTOs
{
    
    public class NotifacationAddDto
    {

        public int SenderId { get; set; }

        public SenderType Sender { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsRead { get; set; }
        public Inventory? Inventory { get; set; }

        public Order? order { get; set; }


    }
}
