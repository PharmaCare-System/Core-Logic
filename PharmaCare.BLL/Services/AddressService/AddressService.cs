using PharmaCare.BLL.DTOs.AddressDTOs;
using PharmaCare.BLL.DTOs.AddressDTOs.CustomerAddressDTOs;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Repository.AddressRepository;
using PharmaCare.DAL.Repository.CustomerAddress;
using PharmaCare.DAL.Repository.CustomerAddressRepository;
using PharmaCare.DAL.Repository.Customers;
using PharmaCare.DAL.Repository.PharmacistAddress;
using PharmaCare.DAL.Repository.Pharmacists;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.AddressService
{
    public class AddressService : IAddressService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;
        private readonly IPharmacistAddressRepository _pharmacistAddressRepository;

        public AddressService(ICustomerAddressRepository customerAddressRepository, IPharmacistAddressRepository pharmacistAddressRepositor)
        {
            _customerAddressRepository = customerAddressRepository;
            _pharmacistAddressRepository = pharmacistAddressRepositor;
        }
        public async Task AddCustomerAddressAsync(CustomerAddressAddDTO customerAddressDTO)
        {

            if(customerAddressDTO.UserType == UserType.Customer)
            { 
                var customerAddressModel = new CustomerAddress()
                {
                    //How to handle Id
                    Country = customerAddressDTO.Country,
                    City = customerAddressDTO.City,
                    streetNumber = customerAddressDTO.streetNumber,
                };

            //if the customer exists, add his address
                _customerAddressRepository.AddAsync(customerAddressModel);
            }
        }

        public Task AddPharmacistAddressAsync(PharmacistAddressAddDTO pharmacistAddressDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAddressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerAddressReadDTO> GetCustomerAsyncById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PharmacistAddressReadDTO> GetPharmacistAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
