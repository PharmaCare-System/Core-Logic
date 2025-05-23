using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.BLL.DTOs.PharmayDTOs;
using PharmaCare.DAL.Repository.Pharmacists;
using pharmacy.DAL;

namespace pharmacare.bll.services.pharmacyserivce
{
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository _pharmacyservice;
        public PharmacyService(IPharmacyRepository pharmacyservice)
        {
            _pharmacyservice = pharmacyservice;
        }

        public async Task AddAsync(PharmacyAddDto pharmacy)
        {
            var pharmacyEntity = new Pharmacy
            {
                Name = pharmacy.Name,
                Location = pharmacy.Address,
            };
            await _pharmacyservice.AddAsync(pharmacyEntity);
        }



        public async Task DeleteAsync(int id)
        {
            var pharmacy = await _pharmacyservice.GetAsyncById(id);
            if (pharmacy == null)
            {
                throw new Exception("Pharmacy not found");
            }
            await _pharmacyservice.SoftDelete(pharmacy);
        }

        public async Task< IEnumerable<PharmacyReadDto>> GetAllAsync()
        {
            var pharmacies = await _pharmacyservice.GetAllAsync();
            return pharmacies.Select(p => new PharmacyReadDto
            {
                Id = p.Id,
                Name = p.Name,
                Address = p.Location,
            });
        }

        public async Task< PharmacyReadDto> GetAsyncById(int id)
        {
            var pharmacy = await _pharmacyservice.GetAsyncById(id);
            if (pharmacy == null)
            {
                throw new Exception("Pharmacy not found");
            }
            return new PharmacyReadDto
            {
                Id = pharmacy.Id,
                Name = pharmacy.Name,
                Address = pharmacy.Location,
            };

        }

        public async Task UpdateAsync(PharmacyUpdateDto pharmacy)
        {
            var pharmacyEntity = await _pharmacyservice.GetAsyncById(pharmacy.Id);
            pharmacyEntity.Name = pharmacy.Name;
            pharmacyEntity.Location = pharmacy.Address;
            pharmacyEntity.MangerPharmacyId = pharmacy.MangerPharmacyId;
        }
    }

}
