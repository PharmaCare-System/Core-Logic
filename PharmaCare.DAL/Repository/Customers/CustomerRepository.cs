using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Customer> GetAll()
        {
            return _context.Customers;
        }
        public Customer GetById(int id)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            return customer;
        }
        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            
            _context.SaveChanges();
        }
    }
}
