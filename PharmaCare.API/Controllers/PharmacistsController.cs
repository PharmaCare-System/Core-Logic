using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.PharmacistDTOs;
using PharmaCare.BLL.Services.PharmacistService;
using PharmaCare.DAL.ExtensionMethods;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacistsController : ControllerBase
    {
        private readonly IPharmacistService _pharmacistService;
        public PharmacistsController(IPharmacistService pharmacistService)
        {
            _pharmacistService = pharmacistService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var pharmacisModel = _pharmacistService.GetAllAsync();
            return Ok(pharmacisModel);
        }
        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        { 
            var pharmacisModel =  _pharmacistService.GetAsyncById(id);
            id.CheckIfNull(pharmacisModel);
            return Ok(pharmacisModel);
        }
        [HttpPost]
        public  IActionResult Add( PharmacistAddDTO pharmacistAddDto)
        {
            if (pharmacistAddDto == null)
            {
                return BadRequest();
            }
             _pharmacistService.AddAsync(pharmacistAddDto);
            return CreatedAtAction(nameof(GetById), new {message = "Pharmacist Added Successfully" });
        }
        [HttpPut("{id}")]
        public IActionResult Update(PharmacistUpdateDTO pharmacistUpdateDto, int id)
        {
            id.CheckIfNull(pharmacistUpdateDto);
            var pharmacisModel = _pharmacistService.GetAsyncById(id);
            _pharmacistService.UpdateAsync(pharmacistUpdateDto, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pharmacistService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("pharmacy/{pharmacyId}")]
        public IActionResult GetPharmacistsByPharmacyId(int pharmacyId)
        {
            var pharmacisModels = _pharmacistService.GetPharmacistsByPharmacyId(pharmacyId);
            return Ok(pharmacisModels);
        }
        [HttpGet("available")]
        public IActionResult GetAvailableForChat()
        {
            var pharmacisModels = _pharmacistService.AvialbelForChat();
            return Ok(pharmacisModels);
        }
        [HttpGet("chat/{id}")]
        public IActionResult GetPharmacistChat(int id)
        {
            var pharmacisModel = _pharmacistService.GetPharmacistChats(id);
            id.CheckIfNull(pharmacisModel);
            return Ok(pharmacisModel);
        }
    }
}
