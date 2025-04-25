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
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService) {
            _inventoryService = inventoryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var inventories = _inventoryService.GetAll();
            return Ok(inventories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inventory = _inventoryService.GetById(id);
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
            _inventoryService.Add(inventory);
            return CreatedAtAction(nameof(GetById), inventory);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, InventoryUpdateDto inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            var existingInventory = _inventoryService.GetById(id);
            if (existingInventory == null)
            {
                return NotFound();
            }
            _inventoryService.Update(inventory);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inventory = _inventoryService.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _inventoryService.Delete(id);
            return NoContent();
        }
    }
}
