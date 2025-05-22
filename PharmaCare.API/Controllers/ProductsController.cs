using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.ProductDTOs;
using PharmaCare.BLL.Services.ProductService;
using PharmaCare.DAL.Models;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("byInventory/{inventoryId}")] 
        public async Task<IActionResult> GetAllByInventoryAsync(int inventoryId)
        {
            var products = await _productService.GetAllByInventoryAsync(inventoryId);
            return products == null ? NotFound() : Ok(products);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetAsyncById(int id)
        {
            try
            {
                var product = await _productService.GetAsyncById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting product");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductAddDTO productDTO)
        {
            try
            {
                await _productService.AddAsync(productDTO);
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
            return StatusCode(201, new { Message = "Product Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(ProductUpdateDTO productDTO, int id)
        {
            var product = await _productService.GetAsyncById(id);
            if (product.Id != id)
                return BadRequest();

            await _productService.UpdateAsync(productDTO, id);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();

        }
        [HttpGet("search")]
        public async Task<IActionResult> GetPagedProductsAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? term = null)
        {
            var result = await _productService.GetPagedProductsAsync(page, pageSize, term);
            if (result == null)
                return NotFound();
            return Ok(result);   
        }
    }
}
