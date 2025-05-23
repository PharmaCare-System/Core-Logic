using PharmaCare.DAL.Repository.GenericRepository;
using PharmaCare.DAL.Models;

namespace PharmaCare.DAL.Repository.Reviews
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        public Task <List<Review>> GetReviewsByProductId(int productId);
        public Task<List<Review>> GetReviewsByCustomerId(int customerId);


    }
}
