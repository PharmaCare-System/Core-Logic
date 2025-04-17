using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using pharmasist.DAL;

namespace PharmaCare.DAL
{
    public class PharmacistRepository :IPharmacistRepository
    {
        private readonly ApplicationDbContext _context;
        public PharmacistRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Pharmacist> GetAll()
        {
            return _context.pharmacists ;
        }
        public Pharmacist GetById(int id)
        {
            return _context.pharmacists.Find(id);
        }
        public void Add(Pharmacist pharmacy)
        {
            _context.pharmacists.Add(pharmacy);
            _context.SaveChanges();
        }
        public void Update(Pharmacist pharmacy)
        {
            _context.pharmacists.Update(pharmacy);
            _context.SaveChanges();
        }
        public void Delete(Pharmacist pharmacy)
        {
            _context.pharmacists.Remove(pharmacy);
            _context.SaveChanges();
        }
    }
}
