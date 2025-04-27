using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.InventoryService
{
    public interface IInventoryService
    {
        public Task< IEnumerable<InventoryReadDTO>> GetAllAsync();
        public Task <InventoryReadDTO>GetAsyncById(int id);
        public Task AddAsync(InventoryAddDTO inventory);
        public Task UpdateAsync(InventoryUpdateDTO inventory,int id);
        public Task DeleteAsync(int id);
    }
}
