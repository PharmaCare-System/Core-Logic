using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using phar;
using PharmaCare.BLL.DTOs.PharmayDTOs;
using PharmaCare.BLL.Services.PharmacySerivce;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacySerivce _serivce;
        public PharmacyController(IPharmacySerivce serivce)
        {
            _serivce = serivce;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var pharmacies = _serivce.GetAll();
            return Ok(pharmacies);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pharmacy = _serivce.GetById(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return Ok(pharmacy);
        }
        [HttpPost]
        public IActionResult Add( PharmacyAddDto pharmacy)
        {
            if (pharmacy == null)
            {
                return BadRequest();
            }
            _serivce.Add(pharmacy);
            return CreatedAtAction(nameof(GetById), pharmacy);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, PharmacyUpdateDto pharmacy)
        {
            if (id != pharmacy.Id)
            {
                return BadRequest();
            }
            var existingPharmacy = _serivce.GetById(id);
            if (existingPharmacy == null)
            {
                return NotFound();
            }
            _serivce.Update(pharmacy);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pharmacy = _serivce.GetById(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            _serivce.Delete(id);
            return NoContent();
        }

    }
}
