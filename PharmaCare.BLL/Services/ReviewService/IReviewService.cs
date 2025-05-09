using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaCare.BLL.DTOs.ProductDTOs;
using PharmaCare.BLL.DTOs.ReviewDTOs;
using PharmaCare.DAL.Models;

namespace PharmaCare.BLL.Services.ReviewService
{
     public interface IReviewService
    {
        public Task AddAsync(ReviewAddDto ReviewDto  );
        public Task UpdateAsync(ReviewUpdateDto reviewDto , int id);
        public Task DeleteAsync(int id);
        public Task<IEnumerable<ReviewReadDto>> GetAllAsync();
        public Task<ReviewReadDto> GetAsyncById(int id);
        public Task<ProductReviewsDto> GetReviewsByProductId(int productId);
        public Task<UserReviewsDto> GetReviewsByCustomerId(int customerId);


    }
}
