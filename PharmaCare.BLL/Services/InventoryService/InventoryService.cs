using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventory.DAL;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.InventoryService
{
    public class InventoryService:IInventoryService
    {
        private readonly IInventoryRepository _inventoryService;
        public InventoryService(IInventoryRepository inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void Add(InventoryAddDto inventory)
        {
            var Inventorymodel = new Inventory

            {
                Name = inventory.Name,
                Location = inventory.Location,
                QuantityStock = inventory.QuantityStock,
                PharmacyId = inventory.PharmacyId
            };
            _inventoryService.Add(Inventorymodel);

        }

        public void Delete(int id)
        {
            var inventory = _inventoryService.GetById(id);
            if (inventory != null)
            {
                _inventoryService.Delete(inventory);
            }
            else
            {
                throw new Exception("Inventory not found");
            }
        }

        public IEnumerable<InventoryReadDto> GetAll()
        {
            var inventories = _inventoryService.GetAll();
            var inventoryModel= inventories.Select(p=> new InventoryReadDto{
                Id = p.Id,

                Name = p.Name,
                Location = p.Location,
                QuantityStock = p.QuantityStock,
                PharmacyId = p.PharmacyId
            }).ToList();
                    return inventoryModel ;

        }

        public InventoryReadDto GetById(int id)
        {
            var inventory = _inventoryService.GetById(id);
            var InventoryModel = new InventoryReadDto
            {
                Id = inventory.Id,
                Name = inventory.Name,
                Location = inventory.Location,
                QuantityStock = inventory.QuantityStock,
                PharmacyId = inventory.PharmacyId

            };

            return InventoryModel;
        }

        public void Update(InventoryUpdateDto inventory)
        {
            var inventoryModel = _inventoryService.GetById(inventory.Id);

            if (inventoryModel != null)
            {
                throw new Exception("Inventory not found");
            }
            inventoryModel.Name = inventory.Name;
            inventoryModel.Location = inventory.Location;
            inventoryModel.QuantityStock = inventory.QuantityStock;
            inventoryModel.PharmacyId = inventory.PharmacyId;
            _inventoryService.Update(inventoryModel);


        }
    }
}
