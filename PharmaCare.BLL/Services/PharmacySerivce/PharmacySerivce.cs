//using system;
//using system.collections.generic;
//using system.linq;
//using system.text;
//using system.threading.tasks;
//using pharmacare.bll.dtos.pharmaydtos;
//using pharmacare.dal.models;
//using pharmacy.dal;
//using pharmasist.dal;

//namespace pharmacare.bll.services.pharmacyserivce
//{
//    public class pharmacyserivce : ipharmacyserivce
//    {
//        private readonly ipharmacyrepository _pharmacyservice;
//        public void add(pharmacyadddto pharmacy)
//        {
//            var pharmacyentity = new pharmacy
//            {
//                address = pharmacy.address,
//                name = pharmacy.name,
//                mangerpharmacyid = pharmacy.mangerpharmacyid,

//            };
//            _pharmacyservice.add(pharmacyentity);
//        }

//        public void delete(int id)
//        {
//            var pharmacy = _pharmacyservice.getbyid(id);
//            if (pharmacy != null)
//            {
//                _pharmacyservice.delete(pharmacy);
//            }
//            else
//            {
//                throw new exception("pharmacy not found");
//            }
//        }

//        public ienumerable<pharmacyreaddto> getall()
//        {
//            var pharmacies = _pharmacyservice.getall();
//            var pharmacymodel = pharmacies.select(p => new pharmacyreaddto
//            {
//                id = p.id,
//                address = p.address,
//                name = p.name,
//                mangerpharmacyid = p.mangerpharmacyid,
//            }).tolist();
//            return pharmacymodel;

//        }

//        public pharmacyreaddto getbyid(int id)
//        {
//            var pharmacy = _pharmacyservice.getbyid(id);
//            if (pharmacy != null)
//            {
//                return new pharmacyreaddto
//                {
//                    id = pharmacy.id,
//                    address = pharmacy.address,
//                    name = pharmacy.name,
//                    mangerpharmacyid = pharmacy.mangerpharmacyid,
//                };
//            }
//            else
//            {
//                throw new exception("pharmacy not found");
//            }
//        }

//        public void update(pharmacyupdatedto pharmacy)
//        {
//            var pharmacyentity = _pharmacyservice.getbyid(pharmacy.id);
//            if (pharmacyentity != null)
//            {
//                pharmacyentity.address = pharmacy.address;
//                pharmacyentity.name = pharmacy.name;
//                pharmacyentity.mangerpharmacyid = pharmacy.mangerpharmacyid;
//                _pharmacyservice.update(pharmacyentity);
//            }
//            else
//            {
//                throw new exception("pharmacy not found");
//            }
//        }
//    }

//}
