using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PharmaCare.DAL.Models
{
    public enum SenderType
    {
       order =1,
        message =2,
        other = 3,
    }
    public class Notifacation
    {

        public int Id { get; set; }

        public int SenderId { get; set; }
      
        public SenderType Sender { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsRead { get; set; }
        public Inventory? Inventory { get; set; }

        public Order? order { get; set; }





    }
    public class OrderNotification : Notifacation
    {
        public Order Sender { get; set; }
    }
    public class MessageNotification : Notifacation
    {
        public Message Sender { get; set; }
    }


}
