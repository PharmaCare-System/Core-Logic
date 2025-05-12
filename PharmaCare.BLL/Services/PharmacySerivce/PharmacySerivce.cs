using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Models;
using PharmaCare.BLL.Services.PharmacySerivce;
using PharmaCare.BLL.DTOs.PharmayDTOs;

namespace pharmacare.bll.services.pharmacyserivce
{
    public class PharmacyService : IPharmacyService
    {
        //private readonly ipharmacyrepository _pharmacyservice;
        //public void add(pharmacyadddto pharmacy)
        //{
        //    var pharmacyentity = new pharmacy
        //    {
        //        address = pharmacy.address,
        //        name = pharmacy.name,
        //        mangerpharmacyid = pharmacy.mangerpharmacyid,

        //    };
        //    _pharmacyservice.add(pharmacyentity);
        //}

        //public void delete(int id)
        //{
        //    var pharmacy = _pharmacyservice.getbyid(id);
        //    if (pharmacy != null)
        //    {
        //        _pharmacyservice.delete(pharmacy);
        //    }
        //    else
        //    {
        //        throw new exception("pharmacy not found");
        //    }
        //}

        //public ienumerable<pharmacyreaddto> getall()
        //{
        //    var pharmacies = _pharmacyservice.getall();
        //    var pharmacymodel = pharmacies.select(p => new pharmacyreaddto
        //    {
        //        id = p.id,
        //        address = p.address,
        //        name = p.name,
        //        mangerpharmacyid = p.mangerpharmacyid,
        //    }).tolist();
        //    return pharmacymodel;

        //}

        //public pharmacyreaddto getbyid(int id)
        //{
        //    var pharmacy = _pharmacyservice.getbyid(id);
        //    if (pharmacy != null)
        //    {
        //        return new pharmacyreaddto
        //        {
        //            id = pharmacy.id,
        //            address = pharmacy.address,
        //            name = pharmacy.name,
        //            mangerpharmacyid = pharmacy.mangerpharmacyid,
        //        };
        //    }
        //    else
        //    {
        //        throw new exception("pharmacy not found");
        //    }
        //}

        //public void update(pharmacyupdatedto pharmacy)
        //{
        //    var pharmacyentity = _pharmacyservice.getbyid(pharmacy.id);
        //    if (pharmacyentity != null)
        //    {
        //        pharmacyentity.address = pharmacy.address;
        //        pharmacyentity.name = pharmacy.name;
        //        pharmacyentity.mangerpharmacyid = pharmacy.mangerpharmacyid;
        //        _pharmacyservice.update(pharmacyentity);
        //    }
        //    else
        //    {
        //        throw new exception("pharmacy not found");
        //    }
        //}
        public void Add(PharmacyAddDto pharmacy)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PharmacyReadDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PharmacyReadDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(PharmacyUpdateDto pharmacy)
        {
            throw new NotImplementedException();
        }
    }

}
