using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Category
{
    public interface ICategoryRepository : IGenericRepository<DAL.Models.Category>
    {
       public Task<DAL.Models.Category> GetCategoryWithProductsAsync(int id);
       public Task<IEnumerable<DAL.Models.Category>> GetActiveCategoriesAsync();



    }
    
}
