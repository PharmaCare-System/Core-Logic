using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models ;

namespace PharmaCare.DAL.Repository.Orders
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<IEnumerable<Order>> GetOrdersByPharmacyIdAsync(int pharmacyId);
        Task<IEnumerable<Order>> GetOrdersByPharmacistIdAsync(int pharmacistId);
        Task<List<Order>> GetOrderProductsAsync(int orderId);




    }
}
