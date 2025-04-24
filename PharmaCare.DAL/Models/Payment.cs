using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Enums;

namespace PharmaCare.DAL.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public PaymentType Type { get; set; }
        public PaymentStatus Status { get; set; }

        // Navigation property for 1-to-1 with Purchase
        public virtual Purchase? Purchase { get; set; }
    }


 
  
}
