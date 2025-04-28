using PharmaCare.BLL.DTOs.AddressDTOs;
using PharmaCare.BLL.DTOs.AddressDTOs.CustomerAddressDTOs;
using PharmaCare.BLL.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.AddressService
{
    public interface IAddressService
    {
        public Task AddCustomerAddressAsync(CustomerAddressAddDTO customerAddressDTO);
        public Task AddPharmacistAddressAsync(PharmacistAddressAddDTO pharmacistAddressDTO);

        public Task<CustomerAddressReadDTO> GetCustomerAsyncById(int id);
        public Task<PharmacistAddressReadDTO> GetPharmacistAsyncById(int id);

        public Task DeleteAddressByIdAsync(int id);
    }
}
