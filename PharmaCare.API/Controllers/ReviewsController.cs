using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaCare.BLL.DTOs.InventoryDTOs;
using PharmaCare.BLL.DTOs.ReviewDTOs;
using PharmaCare.BLL.Services.ReviewService;
using PharmaCare.DAL.ExtensionMethods;
using PharmaCare.DAL.Models;

namespace PharmaCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _reviewService.GetAllAsync();
            return Ok(reviews);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
           var reviews = _reviewService.GetAsyncById(Id);
            return Ok(reviews);
        }
        public IActionResult Add(ReviewAddDto reviewAddDto)
        {    
            _reviewService.AddAsync(reviewAddDto);
            return CreatedAtAction(nameof(GetById), new { Message = "Review Created Successfully" });

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,ReviewUpdateDto reviewUpdateDto)
        {
         
            var Review  = _reviewService.GetAsyncById(id);
            _reviewService.UpdateAsync(reviewUpdateDto, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reviewService.DeleteAsync(id);

            return NoContent();
        }
        [HttpGet("/api/products/{productId}/reviews")]
        public  IActionResult GetReviewsByProductId(int productId)
        {
            var reviews =  _reviewService.GetReviewsByProductId(productId);

            return Ok(reviews);
        }
        [HttpGet("/api/Customers/{customerId}/reviews")]
        public IActionResult GetReviewsByProduct(int CustomerId)
        {
            var reviews = _reviewService.GetReviewsByCustomerId(CustomerId);
            return Ok(reviews);
        }


        }
}
