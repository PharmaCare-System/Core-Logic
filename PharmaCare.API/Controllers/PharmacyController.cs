using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using phar;
using PharmaCare.BLL.DTOs.PharmayDTOs;
using PharmaCare.BLL.Services.PharmacySerivce;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyService _pharmacyService;
        public PharmacyController(IPharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pharmacies = await _pharmacyService.GetAllAsync();
            return Ok(pharmacies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pharmacy = await _pharmacyService.GetAsyncById(id);
            if (pharmacy == null)
            {
                return NotFound("Pharmacy not found");
            }
            return Ok(pharmacy);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PharmacyAddDto pharmacyDto)
        {
            try
            {
                await _pharmacyService.AddAsync(pharmacyDto);
                return StatusCode(201, "Pharmacy Created Successfully");

            }
            catch (Exception ex) {
                return StatusCode(500, new
                {
                    messege = ex.Message,
                    innerException = ex.InnerException
                });
            
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PharmacyUpdateDto pharmacyDto)
        {
            var pharmacy = await _pharmacyService.GetAsyncById(id);
            if (pharmacy == null)
            {
                return NotFound("Pharmacy not found");
            }
            await _pharmacyService.UpdateAsync(pharmacyDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pharmacy = await _pharmacyService.GetAsyncById(id);
            if (pharmacy == null)
            {
                return NotFound("Pharmacy not found");
            }
            await _pharmacyService.DeleteAsync(id);
            return NoContent();
        }



    }
}
