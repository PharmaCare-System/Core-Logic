using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.ProductRepository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Repository.ProductRepository
{
    public class ProductRepository : GenericRepository<Models.Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsByPharmacy(int inventoryId)
        {
            return await _context.Products.Where(p => p.InventoryId == inventoryId).ToListAsync();
        }
    }
    
}
