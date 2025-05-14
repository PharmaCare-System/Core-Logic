using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PharmaCare.BLL.DTOs.ReviewDTOs;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Repository.Reviews;

namespace PharmaCare.BLL.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _ReviewRepository;
        public ReviewService(IReviewRepository ReviewRepository)
        {
            _ReviewRepository = ReviewRepository;
        }

        public async Task AddAsync(ReviewAddDto ReviewDto)
        {
            var review = new DAL.Models.Review
            {
                Id = ReviewDto.Id,
                ReviewDate = ReviewDto.ReviewDate,
                Rating = ReviewDto.Rating,
                Comment = ReviewDto.Comment,
                ProductId = ReviewDto.ProductId,
                CustomerId = ReviewDto.CustomerId
            };
            await _ReviewRepository.AddAsync(review);

        }

        public async Task DeleteAsync(int id)
        {
            var review =await _ReviewRepository.GetAsyncById(id);
            id.CheckIfNull(review);
          await _ReviewRepository.SoftDelete(review);
        }

        public async Task<IEnumerable<ReviewReadDto>> GetAllAsync()
        {
            var reviews = await _ReviewRepository.GetAllAsync();
            var reviewDtos = reviews.Select(r => new ReviewReadDto
            {
                Id = r.Id,
                ReviewDate = r.ReviewDate,
                Rating = r.Rating,
                Comment = r.Comment,
                ProductId = r.ProductId,
            });
            return reviewDtos;
        }

        public async Task<ReviewReadDto> GetAsyncById(int id)
        {
            var review = await _ReviewRepository.GetAsyncById(id);
          id.CheckIfNull(review);
            var reviewDto = new ReviewReadDto
            {
                Id = review.Id,
                ReviewDate = review.ReviewDate,
                Rating = review.Rating,
                Comment = review.Comment,
                ProductId = review.ProductId,
            };
            return reviewDto;
        }

        public async Task<UserReviewsDto> GetReviewsByCustomerId(int customerId)
        {
            var reviews = await _ReviewRepository.GetReviewsByCustomerId(customerId);
            var userReviewsDtos = new UserReviewsDto
            {
                userID = customerId,
                userName = reviews.FirstOrDefault().Customer.       ApplicationUser.FirstName + " " + reviews.FirstOrDefault().Customer.ApplicationUser.LastName,
                UserReviews = reviews.Select(r => new ReviewReadDto
                {
                    Id = r.Id,
                    ReviewDate = r.ReviewDate,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    ProductId = r.ProductId,
                }).ToList()
            };
            return userReviewsDtos;
        }

        public async Task<ProductReviewsDto> GetReviewsByProductId(int productId)
        {
            var reviews = await _ReviewRepository.GetReviewsByProductId(productId);
            var productReviewsDtos = new ProductReviewsDto
            {
                ProductName = reviews.FirstOrDefault()?.Product?.Name,
                ProductReviews = reviews.Select(r => new ReviewReadDto
                {
                    Id = r.Id,
                    ReviewDate = r.ReviewDate,
                    Rating = r.Rating,
                    Comment = r.Comment,
                    ProductId = r.ProductId,
                }).ToList()
            };
            return productReviewsDtos;

        }

        public async Task UpdateAsync(ReviewUpdateDto reviewDto, int id)
        {
            var review = await _ReviewRepository.GetAsyncById(id);
            id.CheckIfNull(review);
            review.ReviewDate = reviewDto.ReviewDate;
            review.Rating = reviewDto.Rating;
            review.Comment = reviewDto.Comment;
            await _ReviewRepository.UpdateAsync(review);

        }
    }
}
