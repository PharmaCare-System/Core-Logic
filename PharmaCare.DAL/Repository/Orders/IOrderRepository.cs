using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models ;

namespace PharmaCare.DAL.Repository.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
    }
}
