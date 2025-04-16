using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Enums
{
    public enum OrderTypes
    {
        Retail,
        Bulk
    }
   public enum OrderStatuses
    {
        Pending,
        Processing,
        Shipped,
        Delivered
    }
}
