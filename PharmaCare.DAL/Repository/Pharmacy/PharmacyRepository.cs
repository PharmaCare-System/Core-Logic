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
        private readonly ApplicationDbContext _context;
        public PharmacyRepository(ApplicationDbContext context) {
            _context = context;
        }

        public void Add(Pharmacy pharmacy)
        {
            _context.pharmacies.Add(pharmacy);
            _context.SaveChanges();
        }

        public void Delete(Pharmacy pharmacy)
        {
            _context.pharmacies.Remove(pharmacy);
            _context.SaveChanges();
        }

        public IQueryable<Pharmacy> GetAll()
        {
            return _context.pharmacies;
        }


        public Pharmacy GetById(int id)
        {
            return _context.pharmacies.Find(id);
        }

        public void Update(Pharmacy pharmacy)
        {
            _context.pharmacies.Update(pharmacy);
            _context.SaveChanges();
        }
    }
}
