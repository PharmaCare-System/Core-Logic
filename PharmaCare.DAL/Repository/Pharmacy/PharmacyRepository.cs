using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCarepharmacy.DAL;
using pharmacy.DAL;
using pharmasist.DAL;

namespace PharmaCarepharmacy.DAL.Repository
{
    public class PharmacyRepository :IPharmacyRepository

    {
        private readonly ApplicationDbContext _Context;
        public PharmacyRepository(ApplicationDbContext context) {
            _Context = context;
        }

        public void Add(Pharmacy pharmacy)
        {
            _Context.pharmacies.Add(pharmacy);
            _Context.SaveChanges();
        }

        public void Delete(Pharmacy pharmacy)
        {
            _Context.pharmacies.Remove(pharmacy);
            _Context.SaveChanges();
        }

        public IQueryable<Pharmacy> GetAll()
        {
            return _Context.pharmacies;
        }


        public Pharmacy GetById(int id)
        {
            return _Context.pharmacies.Find(id);
        }

        public void Update(Pharmacy pharmacy)
        {
            _Context.pharmacies.Update(pharmacy);
            _Context.SaveChanges();
        }
    }
}
