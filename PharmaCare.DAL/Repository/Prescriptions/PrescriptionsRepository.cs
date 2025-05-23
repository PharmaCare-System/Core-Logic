using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace PharmaCare.DAL.Repository.Prescriptions
{
    public class PrescriptionsRepository : GenericRepository<Prescription>, IPrescriptionsRepository
    {
        public PrescriptionsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByDoctorIdAsync(int doctorId)
        {
            return await _DbSet
                .Where(p => p.Pharmacist.Id == doctorId)
                .Include(p => p.Customer)
                .Include(p => p.Pharmacist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId)
        {
            return  await _DbSet
                .Where(p => p.CustomerId == patientId)
                .Include(p => p.Customer)
                .ToListAsync();
}

        public async Task<IEnumerable<Prescription>> GetPrescriptionsByPharmacyIdAsync(int pharmacyId)
        {
            return await _DbSet.Where(Prescriptions => Prescriptions.Pharmacist.PharmacyId == pharmacyId)
                .Include(p => p.Customer)
                .Include(p => p.Pharmacist)
                .ThenInclude(p => p.Pharmacy)
                .ToListAsync();
        }

        public async  Task<IEnumerable<Prescription>> GetPrescriptionsByStatusAsync(string status)
        {
            return await _DbSet.Where(p => p.Status.ToString() == status)
                .Include(p => p.Customer)
                .Include(p => p.Pharmacist)
                .ToListAsync();
        }
    }
}
