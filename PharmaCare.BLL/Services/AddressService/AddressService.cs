using PharmaCare.BLL.DTOs.AddressDTOs;
using PharmaCare.DAL.Enums;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models.UserAddress;
using PharmaCare.DAL.Repository.AddressRepository;
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
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task AddAsync(AddressAddDTO addressDTO)
        {
            var addressModel = new Address()
            {
                Country = addressDTO.Country,
                City = addressDTO.City,
                streetNumber = addressDTO.streetNumber,
                UserId = addressDTO.UserId,
                UserType = addressDTO.UserType
            };

            await _addressRepository.AddAsync(addressModel);
        }

        public async Task DeleteAsync(int id)
        {
            var addressModel = await _addressRepository.GetAsyncById(id);
            id.CheckIfNull(addressModel);

            await _addressRepository.DeleteAsync(addressModel);
        }

        public async Task<IEnumerable<AddressReadDTO>> GetAllAsync()
        {
            var addressModels = await _addressRepository.GetAllAsync();
            var addressDTOs = addressModels.Select(a => new AddressReadDTO()
            {
                Id = a.Id,
                Country = a.Country,
                City = a.City,
                streetNumber = a.streetNumber,
                UserId = a.UserId,
                UserType = a.UserType
            }).ToList();

            return addressDTOs;
        }

        public async Task<AddressReadDTO> GetAsyncById(int id)
        {
            var addressModel = await _addressRepository.GetAsyncById(id);
            var addressDTO = new AddressReadDTO()
            {
                Id = addressModel.Id,
                Country = addressModel.Country,
                City = addressModel.City,
                streetNumber = addressModel.streetNumber,
                UserId = addressModel.UserId,
                UserType = addressModel.UserType
            };

            return addressDTO;
        }

        public async Task UpdateAsync(AddressUpdateDTO addressDTO, int id)
        {
            var addressModel = await _addressRepository.GetAsyncById(id);

            addressModel.Id = addressDTO.Id;
            addressModel.Country = addressDTO.Country;
            addressModel.City = addressDTO.City;
            addressModel.streetNumber = addressDTO.streetNumber;
            addressModel.UserId = addressDTO.UserId;
            addressModel.UserType = addressDTO.UserType;
        }
    }
}
