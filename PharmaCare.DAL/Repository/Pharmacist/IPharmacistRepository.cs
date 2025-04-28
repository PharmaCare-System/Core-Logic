using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Repository.Pharmacists
{
    public interface IPharmacistRepository : IGenericRepository<Pharmacist>
    {
        public Task<Pharmacist> GetPharmacistChats(int id);
        public Task<IEnumerable<Pharmacist>> GetPharmacistByPharmacyId(int id);
        public Task<IEnumerable<Pharmacist>> AvialbelForChat ();
    }
}
