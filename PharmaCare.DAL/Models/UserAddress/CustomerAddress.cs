using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Models.UserAddress
{
    public class CustomerAddress : Address
    {
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
