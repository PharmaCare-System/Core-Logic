using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Database;

namespace PharmaCare.DAL.Repository.Prescriptions
{
    public class PrescriptionsRepository : GenericRepository<Prescription>, IPrescriptionsRepository
    {
        public PrescriptionsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
