using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Enums
{
   public enum OrderStatuses
    {
        Pending,
        Processing,
        Shipped,
        Delivered
    }

    public enum PrescriptionStatus
    {
        Pending,
        Approved,
        Rejected,
        Cancelled,
        Expired

    }
}
