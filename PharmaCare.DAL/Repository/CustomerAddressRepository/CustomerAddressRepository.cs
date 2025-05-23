using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.CustomerAddressRepository;
using PharmaCare.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.CustomerAddress
{
    public class CustomerAddressRepository : GenericRepository<DAL.Models.UserAddress.CustomerAddress>, ICustomerAddressRepository
    {
        public CustomerAddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
