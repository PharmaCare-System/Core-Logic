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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoryModel =await _categoryService.GetAsyncById(id);
            return Ok(categoryModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( CategoryUpdateDTO categoryDTO,int id)
        {
            id.CheckIfNull(categoryDTO);
            var categoryModel =_categoryService.GetAsyncById(id);
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
            if(categoryDTO == null)
            {
                return BadRequest();
            }
           await _categoryService.AddAsync(categoryDTO);
            return CreatedAtAction(nameof(GetById), new { Message = "Category Created Successfully" });


        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive() {
            var categoryModels = await _categoryService.GetActiveCategoriesAsync();
            return Ok(categoryModels);
        }
        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetCategoryWithProducts(int id)
        {
            var categoryModel = await _categoryService.GetCategoryWithProductsAsync(id);
            return Ok(categoryModel);
        }
    }
}
