using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.BLL.Services.InventoryService;
using PharmaCare.DAL.Models;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;
        public InventoryController(IInventoryService service) {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var inventories = _service.GetAll();
            return Ok(inventories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inventory = _service.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }
        [HttpPost]
        public IActionResult Add( InventoryAddDto inventory)
        {
            if (inventory == null)
            {
                return BadRequest();
            }
            _service.Add(inventory);
            return CreatedAtAction(nameof(GetById), inventory);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, InventoryUpdateDto inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            var existingInventory = _service.GetById(id);
            if (existingInventory == null)
            {
                return NotFound();
            }
            _service.Update(inventory);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inventory = _service.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return NoContent();
        }
    }
}
