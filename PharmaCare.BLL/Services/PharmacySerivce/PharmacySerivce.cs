//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using PharmaCare.BLL.DTOs.PharmayDTOs;
//using PharmaCare.DAL.Models;
//using pharmacy.DAL;
//using pharmasist.DAL;

//namespace PharmaCare.BLL.Services.PharmacySerivce
//{
//    public class PharmacySerivce : IPharmacySerivce
//    {
//        private readonly IPharmacyRepository _pharmacyService;
//        public void Add(PharmacyAddDto pharmacy)
//        {
//            var pharmacyEntity = new Pharmacy
//            {
//                Address = pharmacy.Address,
//                Name = pharmacy.Name,
//                MangerPharmacyId = pharmacy.MangerPharmacyId,

//            };
//            _pharmacyService.Add(pharmacyEntity);
//        }

//        public void Delete(int id)
//        {
//            var pharmacy = _pharmacyService.GetById(id);
//            if (pharmacy != null)
//            {
//                _pharmacyService.Delete(pharmacy);
//            }
//            else
//            {
//                throw new Exception("Pharmacy not found");
//            }
//        }

//        public IEnumerable<PharmacyReadDto> GetAll()
//        {
//            var pharmacies = _pharmacyService.GetAll();
//            var pharmacyModel = pharmacies.Select(p => new PharmacyReadDto
//            {
//                Id = p.Id,
//                Address = p.Address,
//                Name = p.Name,
//                MangerPharmacyId = p.MangerPharmacyId,
//            }).ToList();
//            return pharmacyModel;

//        }

//        public PharmacyReadDto GetById(int id)
//        {
//            var pharmacy = _pharmacyService.GetById(id);
//            if (pharmacy != null)
//            {
//                return new PharmacyReadDto
//                {
//                    Id = pharmacy.Id,
//                    Address = pharmacy.Address,
//                    Name = pharmacy.Name,
//                    MangerPharmacyId = pharmacy.MangerPharmacyId,
//                };
//            }
//            else
//            {
//                throw new Exception("Pharmacy not found");
//            }
//        }

//        public void Update(PharmacyUpdateDto pharmacy)
//        {
//            var pharmacyEntity = _pharmacyService.GetById(pharmacy.Id);
//            if (pharmacyEntity != null)
//            {
//                pharmacyEntity.Address = pharmacy.Address;
//                pharmacyEntity.Name = pharmacy.Name;
//                pharmacyEntity.MangerPharmacyId = pharmacy.MangerPharmacyId;
//                _pharmacyService.Update(pharmacyEntity);
//            }
//            else
//            {
//                throw new Exception("Pharmacy not found");
//            }
//        }
//    }

//}
