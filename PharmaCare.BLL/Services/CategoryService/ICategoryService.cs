using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using PharmaCare.BLL.DTOs.Category_DTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.CategoryService
{
    public interface ICategoryService
    {
        
            public Task<CategoryReadDTO> GetAsyncById(int id);
            public Task<IEnumerable<CategoryReadDTO>> GetAllAsync();
            public Task AddAsync(CategoryAddDTO categoryAddDTO);
            public Task UpdateAsync(CategoryUpdateDTO categoryDTO,int id);
            public Task DeleteAsync(int id);  
            public Task< CategoryWithProductsDTO>GetCategoryWithProductsAsync(int id);
            public Task<IEnumerable<CategoryReadDTO>> GetActiveCategoriesAsync();  
        
    }
}
