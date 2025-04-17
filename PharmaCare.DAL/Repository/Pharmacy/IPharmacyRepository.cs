using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;

namespace pharmacy.DAL
{
    public interface IPharmacyRepository
    {
        public IQueryable<Pharmacy> GetAll();
        public Pharmacy GetById(int id);
        void Add(Pharmacy pharmacy);
        void Update(Pharmacy pharmacy);
        void Delete(Pharmacy pharmacy);

    }
}
