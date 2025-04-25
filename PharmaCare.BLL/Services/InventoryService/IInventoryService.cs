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
        public Task< IEnumerable<InventoryReadDto>> GetAllAsync();
        public Task <InventoryReadDto>GetAsyncById(int id);
        public Task AddAync(InventoryAddDto inventory);
        public Task UpdateAsync(InventoryUpdateDto inventory,int id);
        public Task DeleteAsync(int id);
    }
}
