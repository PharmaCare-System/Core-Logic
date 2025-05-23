using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.OrderDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.OrderService
{
    public interface IOrderService
    {
      public Task<IEnumerable<OrderReadDTO>> GetAllAsync();
      public Task<OrderReadDTO> GetAsyncById(int orderId);
      public Task AddAsync(OrderAddDTO order);
      public Task UpdateAsync(int orderId, OrderUpdateDTO order);
      public Task DeleteAsync(int orderId);
      public Task<IEnumerable<OrderDTO>> GetOrdersByCustomerIdAsync(int customerId);
      public Task<IEnumerable<OrderDTO>> GetOrdersByPharmacyIdAsync(int pharmacyId);
      public Task<IEnumerable<OrderDTO>> GetOrdersByPharmacistIdAsync(int pharmacistId);
      public Task<List<OrderDTO>> GetOrderProductsAsync(int orderId);

    }
}
