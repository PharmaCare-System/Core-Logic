using PharmaCare.BLL.DTOs.CustomerDTOs;
using PharmaCare.DAL.Repository.Customers;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.ExtensionMethods;


namespace PharmaCare.BLL.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<CustomerReadDTO>> GetAllAsync()
        {
            var customerModels = await _customerRepository.GetAllAsync();

            var customerDTOs = customerModels
            .Select(c => new CustomerReadDTO()
            {
                FirstName = c.ApplicationUser.FirstName,
                LastName = c.ApplicationUser.LastName,
                Phone = c.ApplicationUser.Phone,
                Email = c.ApplicationUser.Email,
                Birthday = c.ApplicationUser.Birthday,
                Age = c.ApplicationUser.Age,
                Id = c.Id,
            }).ToList();
            return customerDTOs;
        }

        public async Task<CustomerReadDTO> GetAsyncById(int id)
        {
            var customerModel = await _customerRepository.GetAsyncById(id);
            id.CheckIfNull(customerModel);

            var customerDTO = new CustomerReadDTO()
            {
                FirstName = customerModel.ApplicationUser.FirstName,
                LastName = customerModel.ApplicationUser.LastName,
                Id = customerModel.Id,
                Phone = customerModel.ApplicationUser.Phone,
                Email = customerModel.ApplicationUser.Email,
                Birthday = customerModel.ApplicationUser.Birthday,
                Age = customerModel.ApplicationUser.Age,
            };
            return customerDTO;
        }

        public async Task AddAsync(CustomerAddDTO customerDTO)
        {
            var customerModel = new Customer();
            await _customerRepository.AddAsync(customerModel);
        }

        public async Task DeleteAsync(int id)
        {
            var customerModel = await _customerRepository.GetAsyncById(id);
            id.CheckIfNull(customerModel);

            await _customerRepository.SoftDelete(customerModel);
        }

        public async Task UpdateAsync(CustomerUpdateDTO customerDTO, int id)
        {
            var customerModel = await _customerRepository.GetAsyncById(id);
            id.CheckIfNull(customerModel);

            customerModel.ApplicationUser.FirstName = customerDTO.FirstName;
            customerModel.ApplicationUser.LastName = customerDTO.LastName;
            customerModel.ApplicationUser.Phone = customerDTO.Phone;
            customerModel.ApplicationUser.Email = customerDTO.Email;
            customerModel.ApplicationUser.Birthday = customerDTO.Birthday;


            await _customerRepository.UpdateAsync(customerModel);
        }

        public async Task<CustomerReadDTO> GetCustomerByEmail(string email)
        {
            var customerModel = await _customerRepository.GetCustomerByEmail(email);
            customerModel.Id.CheckIfNull(customerModel);

            var customerDTO = new CustomerReadDTO()
            {
                Id = customerModel.Id,
                FirstName = customerModel.ApplicationUser.FirstName,
                LastName = customerModel.ApplicationUser.LastName,
                Age = customerModel.ApplicationUser.Age,
                Email = customerModel.ApplicationUser.Email,
                Birthday = customerModel.ApplicationUser.Birthday,
                Phone = customerModel.ApplicationUser.Phone
            };
            return customerDTO;
        }
    }
}
