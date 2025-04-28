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
            var pharmacists = _pharmacistService.GetAllAsync();
            return Ok(pharmacists);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pharmacist = _pharmacistService.GetAsyncById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }
            return Ok(pharmacist);
        }
        [HttpPost]
        public IActionResult Add( PharmacistAddDTO pharmacist)
        {
            if (pharmacist == null)
            {
                return BadRequest();
            }
            _pharmacistService.AddAsync(pharmacist);
            return CreatedAtAction(nameof(Get), pharmacist);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, PharmacistUpdateDTO pharmacist)
        {
            if (id != pharmacist.Id)
            {
                return BadRequest();
            }
            var existingPharmacist = _pharmacistService.GetAsyncById(id);
            if (existingPharmacist == null)
            {
                return NotFound();
            }
            _pharmacistService.UpdateAsync(pharmacist,existingPharmacist.Id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pharmacist = _pharmacistService.GetAsyncById(id);
            if (pharmacist == null)
            {
                return NotFound();
            }
            _pharmacistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
