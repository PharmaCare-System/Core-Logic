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
        public IEnumerable<PharmacyReadDto> GetAll();
        public PharmacyReadDto GetById(int id);
        void Add(PharmacyAddDto pharmacy);
        void Update(PharmacyUpdateDto pharmacy);
        void Delete(int id);

    }
}
