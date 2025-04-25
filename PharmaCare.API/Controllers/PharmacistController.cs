using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.PharmacistDTOs;
using PharmaCare.BLL.Services.PharmacistService;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistController : ControllerBase
    {
        private readonly IPharmacistService _pharmacistService;
        public PharmacistController(IPharmacistService pharmacistService)
        {
            _pharmacistService = pharmacistService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var pharmacists = _pharmacistService.GetAll();
            return Ok(pharmacists);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pharmacist = _pharmacistService.GetById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }
            return Ok(pharmacist);
        }
        [HttpPost]
        public IActionResult Add( PharmacistAddDto pharmacist)
        {
            if (pharmacist == null)
            {
                return BadRequest();
            }
            _pharmacistService.Add(pharmacist);
            return CreatedAtAction(nameof(Get), pharmacist);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, PharmacistUpdateDto pharmacist)
        {
            if (id != pharmacist.Id)
            {
                return BadRequest();
            }
            var existingPharmacist = _pharmacistService.GetById(id);
            if (existingPharmacist == null)
            {
                return NotFound();
            }
            _pharmacistService.Update(pharmacist);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pharmacist = _pharmacistService.GetById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }
            _pharmacistService.Delete(id);
            return NoContent();
        }
    }
}
