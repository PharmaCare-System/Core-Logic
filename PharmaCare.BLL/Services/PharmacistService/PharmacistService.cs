using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.PharmacistDTOs;
using pharmasist.DAL;

namespace PharmaCare.BLL.Services.PharmacistService
{
    public class PharmacistService:IPharmacistService
    {
        private readonly IPharmacistRepository _pharmacistRepository;
        public PharmacistService(IPharmacistRepository pharmacistRepository)
        {
            _pharmacistRepository = pharmacistRepository;
        }

        public void Add(PharmacistAddDto pharmacistAddDto)
        {
            var pharmacist = new DAL.Models.Pharmacist
            {
                FirstName = pharmacistAddDto.FirstName,
                LastName = pharmacistAddDto.LastName,
                Email = pharmacistAddDto.Email,
                Phone = pharmacistAddDto.Phone,
                BirthDate = pharmacistAddDto.BirthDate,
                Address = pharmacistAddDto.Address,
                Password = pharmacistAddDto.Password,
                PharmacyId = pharmacistAddDto.PharmacyId,
                ManagerPharmacistId = pharmacistAddDto.ManagerPharmacistId,
                HireDate = DateTime.Now,

            };
            _pharmacistRepository.Add(pharmacist);
        }

        public void Delete(int id)
        {
            var pharmacist = _pharmacistRepository.GetById(id);
            if (pharmacist == null)
            {
                throw new Exception("Pharmacist not found");
            }
            _pharmacistRepository.Delete(pharmacist);
        }

        public IEnumerable<PharmacistReadDto> GetAll()
        {
            var pharmacists = _pharmacistRepository.GetAll();
            var pharmacistDtos = pharmacists.Select(p => new PharmacistReadDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Phone = p.Phone,
                BirthDate = p.BirthDate,
                Address = p.Address,
                Password = p.Password,
                PharmacyId = p.PharmacyId,
                ManagerPharmacistId = p.ManagerPharmacistId,
                HireDate = p.HireDate
            });
            return pharmacistDtos;
        }

        public PharmacistReadDto GetById(int id)
        {
            var pharmacist = _pharmacistRepository.GetById(id);
            if (pharmacist == null)
            {
                throw new Exception("Pharmacist not found");
            }
            var pharmacistDto = new PharmacistReadDto
            {
                Id = pharmacist.Id,
                FirstName = pharmacist.FirstName,
                LastName = pharmacist.LastName,
                Email = pharmacist.Email,
                Phone = pharmacist.Phone,
                BirthDate = pharmacist.BirthDate,
                Address = pharmacist.Address,
                Password = pharmacist.Password,
                PharmacyId = pharmacist.PharmacyId,
                ManagerPharmacistId = pharmacist.ManagerPharmacistId,
                HireDate = pharmacist.HireDate
            };
            return pharmacistDto;
        }

        public void Update(PharmacistUpdateDto pharmacy)
        {
            var pharmacist = _pharmacistRepository.GetById(pharmacy.Id);
            
            pharmacist.FirstName = pharmacy.FirstName;
            pharmacist.LastName = pharmacy.LastName;
            pharmacist.Email = pharmacy.Email;
            pharmacist.Phone = pharmacy.Phone;
            pharmacist.BirthDate = pharmacy.BirthDate;
            pharmacist.Address = pharmacy.Address;
            pharmacist.Password = pharmacy.Password;
            pharmacist.PharmacyId = pharmacy.PharmacyId;
            pharmacist.ManagerPharmacistId = pharmacy.ManagerPharmacistId;
            _pharmacistRepository.Update(pharmacist);
        }
    }
}
