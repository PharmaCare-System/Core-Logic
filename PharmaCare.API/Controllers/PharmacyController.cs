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
        public IActionResult GetAll()
        {
            var pharmacies = _pharmacyService.GetAll();
            return Ok(pharmacies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pharmacy = _pharmacyService.GetById(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return Ok(pharmacy);
        }
        [HttpPost]
        public IActionResult Add(PharmacyAddDto pharmacy)
        {
            if (pharmacy == null)
            {
                return BadRequest();
            }
            _pharmacyService.Add(pharmacy);
            return CreatedAtAction(nameof(GetById), pharmacy);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, PharmacyUpdateDto pharmacy)
        {
            if (id != pharmacy.Id)
            {
                return BadRequest();
            }
            var existingPharmacy = _pharmacyService.GetById(id);
            if (existingPharmacy == null)
            {
                return NotFound();
            }
            _pharmacyService.Update(pharmacy);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pharmacy = _pharmacyService.GetById(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            _pharmacyService.Delete(id);
            return NoContent();
        }

    }
}
