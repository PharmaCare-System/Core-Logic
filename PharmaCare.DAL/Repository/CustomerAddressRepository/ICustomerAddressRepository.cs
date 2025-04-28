using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.CustomerAddressRepository
{
    public interface ICustomerAddressRepository : IGenericRepository<DAL.Models.UserAddress.CustomerAddress>
    {

    }
}
