using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.ShoppingCart
{
    public class ShoppingCartRepository : GenericRepository<DAL.Models.ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
