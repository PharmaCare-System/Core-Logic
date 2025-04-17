using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace inventory.DAL
{
    public interface IInventoryRepository
    {
        public IQueryable<Inventory> GetAll();
        public Inventory GetById(int id);
        void Add(Inventory pharmacy);
        void Update(Inventory pharmacy);
        void Delete(Inventory pharmacy);
    }
}
