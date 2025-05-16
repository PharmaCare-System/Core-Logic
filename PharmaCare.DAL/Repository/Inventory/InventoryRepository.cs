using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Repository.InventoryRepository;

namespace PharmaCareInv.DAL.Repository.InventoryRepository
{
    public class InventoryRepository: GenericRepository<Inventory>,IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
