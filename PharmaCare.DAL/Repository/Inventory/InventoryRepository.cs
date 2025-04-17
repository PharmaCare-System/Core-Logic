using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventory.DAL;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;

namespace PharmaCareInv.DAL
{
    public class InventoryRepository:IInventoryRepository
    {
        private readonly ApplicationDbContext  _context;
        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Inventory> GetAll()
        {
            return _context.inventories;
        }
        public Inventory GetById(int id)
        {
            return _context.inventories.Find(id);
        }
        public void Add(Inventory inventory)
        {
            _context.inventories.Add(inventory);
            _context.SaveChanges();
        }
        public void Update(Inventory inventory)
        {
            _context.inventories.Update(inventory);
            _context.SaveChanges();
        }
        public void Delete(Inventory inventory)
        {
            _context.inventories.Remove(inventory);
            _context.SaveChanges();
        }


    }
}
