public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetReviewsByLocationIdAsync(int locationId);
    Task<Review> AddAsync(Review review);
}

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;

    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Review>> GetReviewsByLocationIdAsync(int locationId)
        => await _context.Reviews.Where(r => r.LocationId == locationId).ToListAsync();

    public async Task<Review> AddAsync(Review review)
    {
        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();
        return review;
    }
}
