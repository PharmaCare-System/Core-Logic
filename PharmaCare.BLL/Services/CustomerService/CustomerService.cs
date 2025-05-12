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
                FirstName = c.FirstName,
                LastName = c.LastName,
                Phone = c.PhoneNumber,
                Email = c.Email,
                Birthday = c.Birthday,
                Age = c.Age,
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
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Id = customerModel.Id,
                Phone = customerModel.PhoneNumber,
                Email = customerModel.Email,
                Birthday = customerModel.Birthday,
                Age = customerModel.Age,
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

            await _customerRepository.DeleteAsync(customerModel);
        }

        public async Task UpdateAsync(CustomerUpdateDTO customerDTO, int id)
        {
            var customerModel = await _customerRepository.GetAsyncById(id);
            id.CheckIfNull(customerModel);

            customerModel.FirstName = customerDTO.FirstName;
            customerModel.LastName = customerDTO.LastName;
            customerModel.PhoneNumber = customerDTO.Phone;
            customerModel.Email = customerDTO.Email;
            customerModel.Birthday = customerDTO.Birthday;


            await _customerRepository.UpdateAsync(customerModel);
        }

        public async Task<CustomerReadDTO> GetCustomerByEmail(string email)
        {
            var customerModel = await _customerRepository.GetCustomerByEmail(email);
            customerModel.Id.CheckIfNull(customerModel);

            var customerDTO = new CustomerReadDTO()
            {
                Id = customerModel.Id,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Age = customerModel.Age,
                Email = customerModel.Email,
                Birthday = customerModel.Birthday,
                Phone = customerModel.PhoneNumber
            };
            return customerDTO;
        }
    }
}
