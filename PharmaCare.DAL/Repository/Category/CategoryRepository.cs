using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Category
{
    public class CategoryRepository : GenericRepository<Models.Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
   
}
