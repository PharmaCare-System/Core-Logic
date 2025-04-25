using PharmaCare.BLL.DTOs.ProductDTOs;
using PharmaCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.ProductService
{
    public interface IProductService
    {
        public Task AddAsync(ProductAddDTO productDTO);
        public Task UpdateAsync(ProductUpdateDTO productDTO, int id);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<ProductReadDTO>> GetAllAsync();
        public Task<IEnumerable<ProductReadDTO>> GetAllByInventoryAsync(int inventoryId);
        public Task<ProductReadDTO> GetAsyncById(int id);
    }
}
