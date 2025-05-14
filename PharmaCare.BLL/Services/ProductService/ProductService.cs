using AutoMapper;
using PharmaCare.BLL.DTOs.ProductDTOs;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaCare.BLL.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(ProductAddDTO productDTO)
        {
            var productModel = new Product()
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                ImageURL = productDTO.ImageURL,
                ExpiryDate = productDTO.ExpiryDate,
                BarCode = productDTO.BarCode,
                BulkAllowed = productDTO.BulkAllowed,
                PrescriptionRequired = productDTO.PrescriptionRequired,
                InventoryId = productDTO.InventoryId,
                QuantityInStock = productDTO.QuantityInStock,
            };

            await _productRepository.AddAsync(productModel);
        }

        public async Task DeleteAsync(int id)
        {
            var productModel = await _productRepository.GetAsyncById(id);
            id.CheckIfNull(productModel);

            await _productRepository.SoftDelete(productModel);
        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllAsync()
        {
            var productModels = await _productRepository.GetAllAsync();

            var productDTOs = productModels.
             Select(p => new ProductReadDTO()
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price,
                 ImageURL = p.ImageURL,
                 ExpiryDate = p.ExpiryDate,
                 BarCode = p.BarCode,
                 InventoryId = p.InventoryId,
                 QuantityInStock = p.QuantityInStock
                 
             }).ToList();

            return productDTOs;
        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllByInventoryAsync(int inventoryId)
        {
            var productModels = await _productRepository.GetAllAsync();

            var productDTOs = productModels.
             Select(p => new ProductReadDTO()
             {
                 Id = p.Id,
                 Name = p.Name,
                 Price = p.Price,
                 ImageURL = p.ImageURL,
                 ExpiryDate = p.ExpiryDate,
                 BarCode = p.BarCode,
                 InventoryId = p.InventoryId,
                 QuantityInStock = p.QuantityInStock
             }).ToList();

            return productDTOs;
        }

        public async Task<ProductReadDTO> GetAsyncById(int id)
        {
            var productModel = await _productRepository.GetAsyncById(id);
            id.CheckIfNull(productModel);

            var productDTO = new ProductReadDTO()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Price = productModel.Price,
                ImageURL = productModel.ImageURL,
                ExpiryDate = productModel.ExpiryDate,
                BarCode = productModel.BarCode,
                InventoryId = productModel.InventoryId,
                QuantityInStock = productModel.QuantityInStock
            };

            return productDTO;
        }

        public async Task<PagedResult<ProductReadDTO>> GetPagedProductsAsync(string? term, string? sort, int page=1, int limit=10)
        {

            {
                var pagedProducts = await _productRepository.GetPagedProductsAsync(term, sort, page, limit);

                var itemsDto = _mapper.Map<IEnumerable<ProductReadDTO>>(pagedProducts.Items);

                return new PagedResult<ProductReadDTO>
                {
                    Items = itemsDto,
                    TotalCount = pagedProducts.TotalCount,
                    PageNumber = pagedProducts.PageNumber,
                    PageSize = pagedProducts.PageSize
                };

            }
        }

        public async Task UpdateAsync(ProductUpdateDTO productDTO, int id)
        {
            var productModel = await _productRepository.GetAsyncById(id);
            id.CheckIfNull(productModel);

            productModel.Name = productDTO.Name;
            productModel.Price = productDTO.Price;
            productModel.ImageURL = productDTO.ImageURL;
            productModel.InventoryId = productDTO.InventoryId;
            productModel.QuantityInStock = productDTO.QuantityInStock;
            productModel.BulkAllowed = productDTO.BulkAllowed;
            productModel.PrescriptionRequired = productDTO.PrescriptionRequired;

            await _productRepository.UpdateAsync(productModel);
        }
    }
}
