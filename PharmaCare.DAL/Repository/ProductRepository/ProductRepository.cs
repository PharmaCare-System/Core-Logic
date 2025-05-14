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

        public async Task<PagedResult<Product>> GetPagedProductsAsync(string? term, string? sort, int page, int limit)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(term))
            {
                query = query.Where(p => p.Name.Contains(term)) ;
            }
            if (!string.IsNullOrEmpty(sort))
            {
                query = sort.ToLower() switch
                {
                    "name" => query.OrderBy(p => p.Name),
                    "price" => query.OrderBy(p => p.Price),
                    _ => query.OrderBy(p => p.Id)
                };
            }
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / limit);
            var items = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();
            var pagedResult = new PagedResult<Product>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = page,
                PageSize = limit
            };
            return pagedResult;
        }
    }
    
}
