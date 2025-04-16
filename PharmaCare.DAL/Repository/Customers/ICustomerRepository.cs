using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.DAL.Repository.Customers
{
    public interface ICustomerRepository
    {
        // Add, Update, Delete, GetAll, GetById
        public IQueryable<Customer> GetAll();
        public Customer GetById(int id);
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(Customer customer);

    }
}
