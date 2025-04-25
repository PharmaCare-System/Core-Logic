using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Database;

namespace PharmaCare.DAL.Repository.Addresses
{
    public class CustomerAddressRepository : GenericRepository<Address>, ICustomerAddressRepository 
    {
        public CustomerAddressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
