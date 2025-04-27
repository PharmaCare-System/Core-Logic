using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models.UserNotifications
{
    public class Notifacation
    {

        public int Id { get; set; }

        public int RecieverId { get; set; }

        public SenderType Sender { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsRead { get; set; }
        public Inventory? Inventory { get; set; }

        public Order? order { get; set; }

    }
}
