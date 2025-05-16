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
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService) {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _inventoryService.GetAllAsync();

            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _inventoryService.GetAsyncById(id);
            id.CheckIfNull(inventory);
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Add( InventoryAddDTO inventory)
        {
            if (inventory == null)
            {
                return BadRequest();
            }
            try
            {
                await _inventoryService.AddAsync(inventory);
            }
                        catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    InnerException = ex.InnerException?.Message
                });
            }
            return CreatedAtAction(nameof(GetById), new {Message="Inventory Created Successfully"});

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InventoryUpdateDTO inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            var existingInventory = await _inventoryService.GetAsyncById(id);
            id.CheckIfNull(existingInventory);
            await _inventoryService.UpdateAsync(inventory, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var inventory = _inventoryService.GetAsyncById(id);
            id.CheckIfNull(inventory);
            await _inventoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
