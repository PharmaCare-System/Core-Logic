using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;

namespace PharmaCare.DAL.Repository.Customers
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        public Task<Customer> GetCustomerByEmail(string email);
    }
}
