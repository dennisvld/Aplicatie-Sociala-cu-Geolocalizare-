using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetReviewsByLocationIdAsync(int locationId);
    Task<Review> AddAsync(Review review);
}
