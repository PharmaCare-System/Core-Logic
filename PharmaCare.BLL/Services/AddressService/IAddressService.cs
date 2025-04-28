using PharmaCare.BLL.DTOs.AddressDTOs;
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
        public Task<IEnumerable<AddressReadDTO>> GetAllAsync();
        public Task<AddressReadDTO> GetAsyncById(int id);
        public Task AddAsync(AddressAddDTO addressDTO);
        public Task UpdateAsync(AddressUpdateDTO addressDTO, int id);
        public Task DeleteAsync(int id);
    }
}
