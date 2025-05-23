using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        { }
            public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.ProductOrders).ThenInclude(po => po.Product)
                .Include(o => o.pharmacy)
                .Include(o => o.Pharmacist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByPharmacyIdAsync(int pharmacyId)
        {
            return await _context.Orders
                .Where(o => o.PharmacyId == pharmacyId)
                .Include(o => o.ProductOrders).ThenInclude(po => po.Product)
                .Include(o => o.Customer)
                .Include(o => o.Pharmacist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByPharmacistIdAsync(int pharmacistId)
        {
            return await _context.Orders
                .Where(o => o.PharmacistId == pharmacistId)
                .Include(o => o.ProductOrders).ThenInclude(po => po.Product)
                .Include(o => o.Customer)
                .Include(o => o.pharmacy)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrderProductsAsync(int orderId)
        {
            return await _context.Orders
                .Where(o => o.Id == orderId)
                .Include(o => o.ProductOrders)
                    .ThenInclude(po => po.Product)
                .ToListAsync();
        }
    }
  }
