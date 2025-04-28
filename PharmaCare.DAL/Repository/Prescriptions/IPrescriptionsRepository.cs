using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Repository.Prescriptions
{
    public interface IPrescriptionsRepository : IGenericRepository<Prescription>
    {
        Task<IEnumerable<Prescription>> GetPrescriptionsByPatientIdAsync(int patientId);
        Task<IEnumerable<Prescription>> GetPrescriptionsByPharmacyIdAsync(int pharmacyId);
        Task<IEnumerable<Prescription>> GetPrescriptionsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<Prescription>> GetPrescriptionsByStatusAsync(string status);
    }
}
