using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.PrescriptionDTOs;
using PharmaCare.BLL.Services.PresctiptionService;
using PharmaCare.DAL.ExtensionMethods;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionSerivce _prescriptionService;

        public PrescriptionsController(IPrescriptionSerivce prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prescriptionModels =  await _prescriptionService.GetAllAsync();
            return Ok(prescriptionModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prescriptionModel = await _prescriptionService.GetAsyncById(id);
            return Ok(prescriptionModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(PrescriptionUpdateDTO prescriptionDTO, int id)
        {
            id.CheckIfNull(prescriptionDTO);
            var prescriptionModel = _prescriptionService.GetAsyncById(id);
           await _prescriptionService.UpdateAsync(prescriptionDTO, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _prescriptionService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PrescriptionAddDTO prescriptionDTO)
        {
            if (prescriptionDTO == null)
            {
                return BadRequest();
            }
           await _prescriptionService.AddAsync(prescriptionDTO);
            return CreatedAtAction(nameof(GetById), new { Message = "Prescription Created Successfully" });
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var prescriptionModels = await _prescriptionService.GetPrescriptionsByStatusAsync(status);
            return Ok(prescriptionModels);
        }

        [HttpGet("pharmacy/{pharmacyId}")]
        public async Task<IActionResult> GetByPharmacyId(int pharmacyId)
        {
            var prescriptionModels = await _prescriptionService.GetPrescriptionsByPharmacyIdAsync(pharmacyId);
            return Ok(prescriptionModels);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctorId(int doctorId)
        {
            var prescriptionModels = await _prescriptionService.GetPrescriptionsByDoctorIdAsync(doctorId);
            return Ok(prescriptionModels);
        }
    }
 }
