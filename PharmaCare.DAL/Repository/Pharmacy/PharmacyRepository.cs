using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaCare.DAL.Database;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCarepharmacy.DAL;
using pharmacy.DAL;

namespace PharmaCarepharmacy.DAL.Repository
{
    public class PharmacyRepository : GenericRepository<Pharmacy>, IPharmacyRepository

    {
        public PharmacyRepository(ApplicationDbContext context) : base (context)
        {   
        }
    }
}
