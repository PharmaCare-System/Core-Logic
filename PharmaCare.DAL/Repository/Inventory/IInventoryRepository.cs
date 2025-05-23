using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.InventoryRepository
{
    public interface IInventoryRepository: IGenericRepository<Inventory>
    {
       
    }
}
