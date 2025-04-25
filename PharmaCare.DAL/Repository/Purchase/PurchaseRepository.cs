using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.PurchaseRepository;

namespace PharmaCare.DAL.Repository.Pur
{
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
