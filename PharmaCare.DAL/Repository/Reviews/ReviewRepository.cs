using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace PharmaCare.DAL.Repository.Reviews
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Review>> GetReviewsByCustomerId(int customerId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.CustomerId == customerId)
                .Include(r=>r.Product)
                .Include(r => r.Customer)

                .ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> GetReviewsByProductId(int productId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.ProductId == productId)
                 .Include(r => r.Product)
                .Include(r => r.Customer)
                .ToListAsync();
            return reviews;
        }
    }
}
