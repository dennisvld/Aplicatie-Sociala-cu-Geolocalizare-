public interface IReviewService
{
    Task<IEnumerable<Review>> GetReviewsForLocationAsync(int locationId);
    Task<Review> AddReviewAsync(ReviewDTO reviewDto);
}

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _repository;

    public ReviewService(IReviewRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Review>> GetReviewsForLocationAsync(int locationId) 
        => await _repository.GetReviewsByLocationIdAsync(locationId);

    public async Task<Review> AddReviewAsync(ReviewDTO reviewDto)
    {
        var review = new Review
        {
            Content = reviewDto.Content,
            Rating = reviewDto.Rating,
            LocationId = reviewDto.LocationId
        };
        return await _repository.AddAsync(review);
    }
}
