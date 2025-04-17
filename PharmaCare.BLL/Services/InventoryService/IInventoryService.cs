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
        public IEnumerable<InventoryReadDto> GetAll();
        public InventoryReadDto GetById(int id);
        void Add(InventoryAddDto inventory);
        void Update(InventoryUpdateDto inventory);
        void Delete(int id);
    }
}
