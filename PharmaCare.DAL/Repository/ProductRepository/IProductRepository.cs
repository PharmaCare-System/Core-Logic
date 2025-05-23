using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public Task<IEnumerable<Product>> GetAllProductsByPharmacy(int inventoryId);
        //public Task<PagedResult<Product>> GetPagedProductsAsync(string? term,string?sort, int page,int limit);
    }
}
