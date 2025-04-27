using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.PrescriptionDTOs;

namespace PharmaCare.BLL.Services.PresctiptionService
{
    public interface IPrescriptionSerivce
    {
        public Task AddAsync(PrescriptionAddDTO prescriptionDTO);
        public Task UpdateAsync(PrescriptionUpdateDTO prescriptionDTO, int id);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<PrescriptionReadDTO>> GetAllAsync();
        public Task <IEnumerable<PrescriptionReadDTO>> GetPrescriptionsByStatusAsync(string Staute);
        public Task<IEnumerable<PrescriptionReadDTO>> GetPrescriptionsByPharmacyIdAsync(int pharmacyId);
        public Task<IEnumerable<PrescriptionReadDTO>> GetPrescriptionsByDoctorIdAsync(int doctorId);
        public Task<PrescriptionReadDTO> GetAsyncById(int id);


    }
}
