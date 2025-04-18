using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;
using PharmaCare.DAL.Database;

namespace PharmaCare.DAL.Repository.Reviews
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
