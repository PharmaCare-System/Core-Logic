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

        [HttpGet("{inventoryId}")]
        public async Task<IActionResult> GetAllByInventoryAsync(int inventoryId)
        {
            var products = await _productService.GetAllByInventoryAsync(inventoryId);
            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsyncById(int id)
        {
            var product = await _productService.GetAsyncById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductAddDTO productDTO)
        {
            await _productService.AddAsync(productDTO);
            return CreatedAtAction(nameof(GetAsyncById), new { Message = "Product Created Successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(ProductUpdateDTO productDTO, int id)
        {
            var product = await _productService.GetAsyncById(id);
            if (product.Id != id)
                return BadRequest();

            await _productService.UpdateAsync(productDTO, id);
            return CreatedAtAction(nameof(GetAsyncById), new { Message = "Product Created Successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _productService.DeleteAsync(id);
            return CreatedAtAction(nameof(GetAsyncById), new { Message = "Product Deleted Successfully" });
        }
    }
}
