﻿using System;
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
        public async Task AddAsync(Pharmacist pharmacist)
        {
            if (pharmacist == null)
            {
                return;
            }
            _context.Users.Add(pharmacist);
        }

        public async Task<IEnumerable<Pharmacist>> GetAllAsync()
        {
            return await _context.Users.OfType<Pharmacist>().ToListAsync();
        }
        public async Task<IEnumerable<Pharmacist>> AvialbelForChat()
        {
            var pharmacists = await _context.Users.OfType<Pharmacist>()
                .Where(p => p.IsActive == true)
                .ToListAsync();
            return pharmacists;
        }

        public async Task<IEnumerable<Pharmacist>> GetPharmacistByPharmacyId(int id)
        {
            var pharmacists = await _context.Users.OfType<Pharmacist>()
                .Where(p => p.PharmacyId == id)
                .ToListAsync();
            return pharmacists;
        }

        public async Task<Pharmacist> GetPharmacistChats(int id)
        {
            var pharmacist = await _context.Users.OfType<Pharmacist>()
                .Include(p => p.Chats)
                .ThenInclude(p=>p.Messages)
                .FirstOrDefaultAsync(p => p.Id == id);
            return pharmacist;


        }
    }
}
