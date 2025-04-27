using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.BLL.Services.InventoryService;
using PharmaCare.DAL.ExtensionMethods;
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
            var inventories = _service.GetAllAsync();
            return Ok(inventories);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inventory = _service.GetAsyncById(id);
            id.CheckIfNull(inventory);
            return Ok(inventory);
        }
        [HttpPost]
        public IActionResult Add( InventoryAddDTO inventory)
        {
            if (inventory == null)
            {
                return BadRequest();
            }
            _service.AddAsync(inventory);
            return CreatedAtAction(nameof(GetById), new {Message="Inventory Created Successfully"});
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, InventoryUpdateDTO inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            var existingInventory = _service.GetAsyncById(id);
            id.CheckIfNull(existingInventory);
            _service.UpdateAsync(inventory, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inventory = _service.GetAsyncById(id);
            id.CheckIfNull(inventory);
            _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
