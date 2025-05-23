using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Enums
{
   public enum OrderStatuses
    {
        Pending = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4
    }

    public enum PrescriptionStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Cancelled = 4,
        Expired = 5
    }
    public enum PaymentStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3,
        Refunded = 4
    }
}
