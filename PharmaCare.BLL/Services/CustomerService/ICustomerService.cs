using PharmaCare.BLL.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.CustomerService
{
    public interface ICustomerService
    {
        // Add, Update, Delete, GetAll, GetById
        public Task<IEnumerable<CustomerReadDTO>> GetAllAsync();
        public Task<CustomerReadDTO> GetAsyncById(int id);
        public Task AddAsync(CustomerAddDTO customer);
        public Task UpdateAsync(CustomerUpdateDTO customer, int id);
        public Task DeleteAsync(int id);
        public Task<CustomerReadDTO> GetCustomerByEmail(string email);
    }
}
