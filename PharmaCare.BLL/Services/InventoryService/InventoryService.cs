﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Repository.InventoryRepository;
using PharmaCareInv.DAL;
using PharmaCareInv.DAL.Repository.InventoryRepository;

namespace PharmaCare.BLL.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task AddAsync(InventoryAddDTO inventory)
        {
            var inventoryModel = new Inventory
            {
                Name = inventory.Name,
                Location = inventory.Location,
                PharmacyId = inventory.PharmacyId,

            };
            await _inventoryRepository.AddAsync(inventoryModel);
        }

        public async Task DeleteAsync(int id)
        {
            var inventoryModel = await _inventoryRepository.GetAsyncById(id);
             id.CheckIfNull(inventoryModel);
            await _inventoryRepository.SoftDelete(inventoryModel);
        }

        public async Task<IEnumerable<InventoryReadDTO>> GetAllAsync()
        {
            var inventories =await _inventoryRepository.GetAllAsync();
            var inventoryDto = inventories.Select(i => new InventoryReadDTO
            {
                Id = i.Id,
                Name = i.Name,
                Location = i.Location,
                PharmacyId = i.PharmacyId
            });
            return inventoryDto;
        }

        public async Task<InventoryReadDTO> GetAsyncById(int id)
        {
            var inventoryModel =await  _inventoryRepository.GetAsyncById(id);
            id.CheckIfNull(inventoryModel);
            var inventoryDto = new InventoryReadDTO
            {
                Id = inventoryModel.Id,
                Name = inventoryModel.Name,
                Location = inventoryModel.Location,
            };
            return inventoryDto;       
        }

        public async Task UpdateAsync(InventoryUpdateDTO inventory, int id)
        {
            var inventoryModel = await _inventoryRepository.GetAsyncById(id);
            id.CheckIfNull(inventoryModel);
            inventoryModel.Name = inventory.Name;
            inventoryModel.Location = inventory.Location;
            inventoryModel.PharmacyId = inventory.PharmacyId;
            await _inventoryRepository.UpdateAsync(inventoryModel);

        }
    }
}
