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
using PharmaCare.BLL.ExtensionMethods;


namespace PharmaCare.BLL.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _repository;
        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<CustomerReadDTO> GetAll()
        {
            var customersRead = _repository.GetAll()
                                            .Select(c => new CustomerReadDTO()
                                                    {
                                                        FirstName = c.FirstName,
                                                        LastName = c.LastName,
                                                        Phone = c.Phone,
                                                        Email = c.Email,
                                                        Birthday = c.Birthday,
                                                        Age = c.Age,
                                                        Id = c.Id,
                                                    }).ToList();
            return customersRead;
            
        }

        public CustomerReadDTO GetById(int id)
        {
            var customermodel = _repository.GetById(id); 
            id.CheckIfNull(customermodel);

            var customerRead = new CustomerReadDTO()
            {
                FirstName = customermodel.FirstName,
                LastName = customermodel.LastName,
                Id = customermodel.Id,
                Phone = customermodel.Phone,
                Email = customermodel.Email,
                Birthday = customermodel.Birthday,
                Age = customermodel.Age,
            };
            return customerRead;
        }
        public void Add(CustomerAddDTO customer)
        {
            var customerModel = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                Birthday = customer.Birthday,
                Password = customer.Password
            };
            _repository.Add(customerModel);
        }

        public void Delete(int id)
        {
            var customerToDelete = _repository.GetById(id);
            id.CheckIfNull<Customer>(customerToDelete);

            _repository.Delete(customerToDelete);
        }



        public void Update(CustomerUpdateDTO customer, int id)
        {
            var customerModel = _repository.GetById(id);
            id.CheckIfNull(customerModel);

            customerModel.FirstName = customer.FirstName;
            customerModel.LastName = customer.LastName;
            customerModel.Phone = customer.Phone;
            customerModel.Email = customer.Email;
            customerModel.Birthday = customer.Birthday;
            customerModel.Password = customer.Password;

            _repository.Update(customerModel);
        }
    }
}
