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
        public IActionResult GetAll()
        {
            var prescriptionModels = _prescriptionService.GetAllAsync();
            return Ok(prescriptionModels);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var prescriptionModel = _prescriptionService.GetAsyncById(id);
            return Ok(prescriptionModel);
        }
        [HttpPut("{id}")]
        public IActionResult Update(PrescriptionUpdateDTO prescriptionDTO, int id)
        {
            id.CheckIfNull(prescriptionDTO);
            var prescriptionModel = _prescriptionService.GetAsyncById(id);
            _prescriptionService.UpdateAsync(prescriptionDTO, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _prescriptionService.DeleteAsync(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add(PrescriptionAddDTO prescriptionDTO)
        {
            if (prescriptionDTO == null)
            {
                return BadRequest();
            }
            _prescriptionService.AddAsync(prescriptionDTO);
            return CreatedAtAction(nameof(GetById), new { Message = "Prescription Created Successfully" });
        }
        [HttpGet("status")]
        public IActionResult GetByStatus(string status)
        {
            var prescriptionModels = _prescriptionService.GetPrescriptionsByStatusAsync(status);
            return Ok(prescriptionModels);
        }
        [HttpGet("pharmacy/{pharmacyId}")]
        public IActionResult GetByPharmacyId(int pharmacyId)
        {
            var prescriptionModels = _prescriptionService.GetPrescriptionsByPharmacyIdAsync(pharmacyId);
            return Ok(prescriptionModels);
        }
        [HttpGet("doctor/{doctorId}")]
        public IActionResult GetByDoctorId(int doctorId)
        {
            var prescriptionModels = _prescriptionService.GetPrescriptionsByDoctorIdAsync(doctorId);
            return Ok(prescriptionModels);
        }

    }
 }
