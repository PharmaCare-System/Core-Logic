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
        public async Task<IActionResult> GetAll()
        {
            var pharmacisModel = await _pharmacistService.GetAllAsync();
            return Ok(pharmacisModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        { 
            var pharmacisModel =  await _pharmacistService.GetAsyncById(id);
            id.CheckIfNull(pharmacisModel);
            return Ok(pharmacisModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add( PharmacistAddDTO pharmacistAddDto)
        {
            if (pharmacistAddDto == null)
            {
                return BadRequest();
            }
             await _pharmacistService.AddAsync(pharmacistAddDto);
            return CreatedAtAction(nameof(GetById), new {message = "Pharmacist Added Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(PharmacistUpdateDTO pharmacistUpdateDto, int id)
        {
            id.CheckIfNull(pharmacistUpdateDto);
            var pharmacisModel = await _pharmacistService.GetAsyncById(id);
           await _pharmacistService.UpdateAsync(pharmacistUpdateDto, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _pharmacistService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("pharmacy/{pharmacyId}")]
        public async Task<IActionResult> GetPharmacistsByPharmacyId(int pharmacyId)
        {
            var pharmacisModels = await _pharmacistService.GetPharmacistsByPharmacyId(pharmacyId);
            return Ok(pharmacisModels);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableForChat()
        {
            var pharmacisModels = await _pharmacistService.AvialbelForChat();
            return Ok(pharmacisModels);
        }

        [HttpGet("chat/{id}")]
        public async Task<IActionResult> GetPharmacistChat(int id)
        {
            var pharmacisModel = await _pharmacistService.GetPharmacistChats(id);
            id.CheckIfNull(pharmacisModel);
            return Ok(pharmacisModel);
        }
    }
}
