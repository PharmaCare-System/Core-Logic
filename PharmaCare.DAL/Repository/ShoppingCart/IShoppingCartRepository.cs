using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.ShoppingCart
{
    public interface IShoppingCartRepository : IGenericRepository<DAL.Models.ShoppingCart>
    {
    }
}
