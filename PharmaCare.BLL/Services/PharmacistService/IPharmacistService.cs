using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.PharmacistDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.PharmacistService
{
    public interface IPharmacistService
    {
        public Task <IEnumerable<PharmacistReadDTO>> GetAllAsync();
        public Task <PharmacistReadDTO> GetAsyncById(int id);
        public Task AddAsync(PharmacistAddDTO pharmacistDTO);
        public Task UpdateAsync(PharmacistUpdateDTO pharmacistDTO, int id);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<PharmacistReadDTO>> GetPharmacistsByPharmacyId(int pharmacyId);
        public Task<PharmacistChatsDTO> GetPharmacistChats(int id);
        public Task<IEnumerable<PharmacistReadDTO>> AvialbelForChat();



    }
}
