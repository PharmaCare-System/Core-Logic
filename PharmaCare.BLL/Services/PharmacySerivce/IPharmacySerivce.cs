using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.PharmayDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.PharmacySerivce
{
    public interface IPharmacyService
    {
        public Task<IEnumerable<PharmacyReadDto>> GetAllAsync();
        public Task< PharmacyReadDto> GetAsyncById(int id);
        public Task  AddAsync(PharmacyAddDto pharmacy);
        public Task UpdateAsync(PharmacyUpdateDto pharmacy);
        public Task DeleteAsync(int id);

    }
}
