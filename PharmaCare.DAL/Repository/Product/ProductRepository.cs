using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.ProductRepository;

namespace PharmaCare.DAL.Repository.Product
{
    public class ProductRepository : GenericRepository<Models.Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
