using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PharmaCare.DAL.Repository.Customers
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Include(c => c.ApplicationUser).ToListAsync();
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _context.Customers.Include(c=>c.ApplicationUser)
                                           .FirstOrDefaultAsync(c => c.ApplicationUser.Email == email);
        }
    }
}
