using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.Category_DTOs;
using PharmaCare.BLL.DTOs.ProductDTOs;
using PharmaCare.BLL.Services.CategoryService;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.Category;

namespace PharmaCare.BLL.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       

        public async Task AddAsync(CategoryAddDTO categoryAddDTO)
        {
            var categoryModel = new DAL.Models.Category
            {
                CategoryName = categoryAddDTO.CategoryName,
                IsActive = true
            };
            await _categoryRepository.AddAsync(categoryModel);

        }

        public async Task DeleteAsync(int id)
        {
            var categoryModel = await _categoryRepository.GetAsyncById(id);
            id.CheckIfNull(categoryModel);
            categoryModel.IsActive = false;

            await _categoryRepository.SoftDelete(categoryModel);
        }

        public async Task<IEnumerable<CategoryReadDTO>> GetActiveCategoriesAsync()  
        {
            var categoriesModels = await _categoryRepository.GetActiveCategoriesAsync();
            var categoryDTOs = categoriesModels.Select(c => new CategoryReadDTO
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                IsActive = c.IsActive
            }).ToList();
            return categoryDTOs;


        }

        public async Task<IEnumerable<CategoryReadDTO>> GetAllAsync()
        {
            var categoriesModels = await _categoryRepository.GetAllAsync();
            var categoryDTOs = categoriesModels.Select(c => new CategoryReadDTO
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                IsActive = c.IsActive
            }).ToList();
            return categoryDTOs;
        }

        public async Task<CategoryReadDTO> GetAsyncById(int id)
        {
            var categoryModel =await  _categoryRepository.GetAsyncById(id);
            id.CheckIfNull(categoryModel);
            var categoryDto = new CategoryReadDTO
            {
                Id = categoryModel.Id,
                CategoryName = categoryModel.CategoryName,
                IsActive = categoryModel.IsActive
            };
            return categoryDto;

        }

        public async Task<CategoryWithProductsDTO> GetCategoryWithProductsAsync(int id)
        {
            var categoryModel = await _categoryRepository.GetCategoryWithProductsAsync(id);
            id.CheckIfNull(categoryModel);



            return new CategoryWithProductsDTO
            {
                Id = categoryModel.Id,
                CategoryName = categoryModel.CategoryName,
                Products = categoryModel.Products.Select(p => new ProductReadDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageURL = p.ImageURL,
                    ExpiryDate = p.ExpiryDate,
                    BarCode = p.BarCode,
                    InventoryId = p.InventoryId,
                    QuantityInStock = p.QuantityInStock,
                    CategoryId = p.CategoryId


                }).ToList()

            };




        }

        public async Task UpdateAsync(CategoryUpdateDTO categoryDTO, int id)
        {
            var categoryModel = await _categoryRepository.GetAsyncById(id);
            id.CheckIfNull(categoryModel);
            categoryModel.CategoryName = categoryDTO.CategoryName;
            categoryModel.IsActive = categoryDTO.IsActive;
            await _categoryRepository.UpdateAsync(categoryModel);
        }

    }

    }
