using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Category
{
    public class CategoryRepository : GenericRepository<Models.Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        { }
            public async Task<IEnumerable<DAL.Models.Category>> GetActiveCategoriesAsync()
        {
            return await _DbSet
                .Where(c => c.IsActive == true)
                .ToListAsync();
        }
        public async Task<Models.Category> GetCategoryWithProductsAsync(int id)
        {
            var categoryModel = await _DbSet
                .Where(c=> c.Id == id)
                .Include(c => c.Products)
                .FirstOrDefaultAsync();
            return categoryModel;
        }
    }
    }
  
