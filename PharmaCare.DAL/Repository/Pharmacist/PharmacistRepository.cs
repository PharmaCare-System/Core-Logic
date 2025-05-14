using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace PharmaCare.DAL.Repository.Pharmacists
{
    public class PharmacistRepository : GenericRepository<Pharmacist>, IPharmacistRepository
    {
        public PharmacistRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Pharmacist>> GetAllAsync()
        {
            return await _context.Pharmacists.Include(p=>p.ApplicationUser).ToListAsync();
        }
        public async Task<IEnumerable<Pharmacist>> AvialbelForChat()
        {
            var pharmacists = await _context.Pharmacists
                .Include(p => p.ApplicationUser)
                .Where(p => p.IsActive == true)
                .ToListAsync();
            return pharmacists;
        }

        public async Task<IEnumerable<Pharmacist>> GetPharmacistByPharmacyId(int id)
        {
            var pharmacists = await _context.Pharmacists
                .Where(p => p.PharmacyId == id)
                .ToListAsync();
            return pharmacists;
        }

        public async Task<Pharmacist> GetPharmacistChats(int id)
        {
            var pharmacist = await _context.Pharmacists
                .Include(p => p.Chats)
                .ThenInclude(p=>p.Messages)
                .FirstOrDefaultAsync(p => p.Id == id);
            return pharmacist;


        }
    }
}
