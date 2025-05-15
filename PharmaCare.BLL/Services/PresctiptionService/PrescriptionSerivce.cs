using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.PrescriptionDTOs;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Repository.Prescriptions;

namespace PharmaCare.BLL.Services.PresctiptionService
{
    public class PrescriptionSerivce : IPrescriptionSerivce
    {
        private readonly IPrescriptionsRepository _prescriptionsRepository;
        public PrescriptionSerivce(IPrescriptionsRepository prescriptionsRepository)
        {
            _prescriptionsRepository = prescriptionsRepository;
        }

        public async Task AddAsync(PrescriptionAddDTO prescriptionDTO)
        {
            var prescriptionModel = new DAL.Models.Prescription
            {
                UploadDate = prescriptionDTO.UploadDate,
                Status = prescriptionDTO.Status,
                ImageURL = prescriptionDTO.Image
            };
            await _prescriptionsRepository.AddAsync(prescriptionModel);
        }

        public async Task DeleteAsync(int id)
        {
            var prescriptionModel = await _prescriptionsRepository.GetAsyncById(id);
            
            id.CheckIfNull(prescriptionModel);
            _prescriptionsRepository.SoftDelete(prescriptionModel);

           
        }

        public async Task<IEnumerable<PrescriptionReadDTO>> GetAllAsync()
        {
            var prescriptionModels = await _prescriptionsRepository.GetAllAsync();
            var prescriptionDTOs = prescriptionModels.Select(p => new PrescriptionReadDTO
            {
                Id = p.Id,
                UploadDate = p.UploadDate,
                Status = p.Status,
                Image = p.ImageURL
            }).ToList();
            return prescriptionDTOs;


        }

        public async Task<PrescriptionReadDTO> GetAsyncById(int id)
        {
            var prescriptionModel = await _prescriptionsRepository.GetAsyncById(id);
            id.CheckIfNull(prescriptionModel);
            var prescriptionDTO = new PrescriptionReadDTO
            {
                Id = prescriptionModel.Id,
                UploadDate = prescriptionModel.UploadDate,
                Status = prescriptionModel.Status,
                Image = prescriptionModel.ImageURL
            };
            return prescriptionDTO;
        }

        public async Task<IEnumerable<PrescriptionReadDTO>> GetPrescriptionsByDoctorIdAsync(int doctorId)
        {
            var prescriptionModels = await _prescriptionsRepository.GetPrescriptionsByDoctorIdAsync(doctorId);
            var prescriptionDTOs = prescriptionModels.Select(p => new PrescriptionReadDTO
            {
                Id = p.Id,
                UploadDate = p.UploadDate,
                Status = p.Status,
                Image = p.ImageURL
            }).ToList();
            return prescriptionDTOs;

        }

        public async Task<IEnumerable<PrescriptionReadDTO>> GetPrescriptionsByPharmacyIdAsync(int pharmacyId)
        {
            var prescriptionModels = await _prescriptionsRepository.GetPrescriptionsByPharmacyIdAsync(pharmacyId);
            var prescriptionDTOs = prescriptionModels.Select(p => new PrescriptionReadDTO
            {
                Id = p.Id,
                UploadDate = p.UploadDate,
                Status = p.Status,
                Image = p.ImageURL
            }).ToList();
            return prescriptionDTOs;
        }

        public async Task<IEnumerable<PrescriptionReadDTO>> GetPrescriptionsByStatusAsync(string Staute)
        {
            var prescriptionModels = await _prescriptionsRepository.GetPrescriptionsByStatusAsync(Staute);
            var prescriptionDTOs = prescriptionModels.Select(p => new PrescriptionReadDTO
            {
                Id = p.Id,
                UploadDate = p.UploadDate,
                Status = p.Status,
                Image = p.ImageURL
            }).ToList();
            return prescriptionDTOs;
        }

        public async Task UpdateAsync(PrescriptionUpdateDTO prescriptionDTO, int id)
        {
            var prescriptionModel = await _prescriptionsRepository.GetAsyncById(id);
            id.CheckIfNull(prescriptionModel);
            prescriptionModel.UploadDate = prescriptionDTO.UploadDate;
            prescriptionModel.Status = prescriptionDTO.Status;
            prescriptionModel.ImageURL = prescriptionDTO.Image;
            await _prescriptionsRepository.UpdateAsync(prescriptionModel);

        }

        
    }
}
