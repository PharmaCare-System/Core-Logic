using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.Category_DTOs;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.BLL.Services.CategoryService;
using PharmaCare.DAL.ExtensionMethods;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var categoryModels =await _categoryService.GetAllAsync();
            return Ok(categoryModels);
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetAsyncById(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, CategoryUpdateDTO categoryDTO)
        {
            id.CheckIfNull(categoryDTO);
            var categoryModel =await _categoryService.GetAsyncById(id);
          await  _categoryService.UpdateAsync(categoryDTO, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _categoryService?.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryDTO)
        {
            await _categoryService.AddAsync(categoryDTO);
            return StatusCode(201, new { Message = "Category Created Successfully" });

        }

            [HttpGet("active")]
        public async Task<IActionResult> GetActive() {
            var categoryModels = await _categoryService.GetActiveCategoriesAsync();
            return Ok(categoryModels);
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int id)
        {
            try
            {
                var categoryModel = await _categoryService.GetCategoryWithProductsAsync(id);
                return Ok(categoryModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while retrieving the category with products.",
                    Error = ex.Message,
                    inner = ex.InnerException
});

            }

        }
    }
}
