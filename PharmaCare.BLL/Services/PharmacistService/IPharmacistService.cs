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
        public IEnumerable<PharmacistReadDto> GetAll();
        public PharmacistReadDto GetById(int id);
        void Add(PharmacistAddDto pharmacy);
        void Update(PharmacistUpdateDto pharmacy);
        void Delete(int id);
    }
}
