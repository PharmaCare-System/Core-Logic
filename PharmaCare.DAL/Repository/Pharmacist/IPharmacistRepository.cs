using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Models;            

namespace pharmasist.DAL
{
    public interface  IPharmacistRepository
    {
        public IQueryable<Pharmacist> GetAll();
        public Pharmacist GetById(int id);
        void Add(Pharmacist pharmacy);
        void Update(Pharmacist pharmacy);
        void Delete(Pharmacist pharmacy);


    }
}
