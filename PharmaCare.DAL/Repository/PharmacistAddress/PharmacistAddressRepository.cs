using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.PharmacistAddress
{
    public class PharmacistAddressRepository : GenericRepository<DAL.Models.UserAddress.PharmacistAddress>, IPharmacistAddressRepository
    {
        public PharmacistAddressRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
