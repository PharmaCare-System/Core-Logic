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
        public IActionResult GetAll()
        {
            var categoryModels = _categoryService.GetAllAsync();
            return Ok(categoryModels);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var categoryModel = _categoryService.GetAsyncById(id);
            return Ok(categoryModel);
        }
        [HttpPut("{id}")]
        public IActionResult Update( CategoryUpdateDTO categoryDTO,int id)
        {
            id.CheckIfNull(categoryDTO);
            var categoryModel =_categoryService.GetAsyncById(id);
            _categoryService.UpdateAsync(categoryDTO, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService?.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddDTO categoryDTO)
        {
            if(categoryDTO == null)
            {
                return BadRequest();
            }
            _categoryService.AddAsync(categoryDTO);
            return CreatedAtAction(nameof(GetById), new { Message = "Category Created Successfully" });


        }
        [HttpGet("active")]

        public IActionResult GetActive() {
            var categoryModels = _categoryService.GetActiveCategoriesAsync();
            return Ok(categoryModels);
        }
        [HttpGet("{id}/products")]
        public IActionResult GetCategoryWithProducts(int id)
        {
            var categoryModel = _categoryService.GetCategoryWithProductsAsync(id);
            return Ok(categoryModel);
        }

    }
}
