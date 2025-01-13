using Xunit;
using Moq;
using System.Threading.Tasks;

public class ReviewTests
{
    [Fact]
    public async Task AddReview_ValidData_ReturnsReview()
    {
        // Arrange
        var mockRepo = new Mock<IReviewRepository>();
        var review = new Review { Id = 1, Content = "Great Place", Rating = 5, LocationId = 1 };
        mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Review>())).ReturnsAsync(review);
        var service = new ReviewService(mockRepo.Object);

        // Act
        var result = await service.AddReviewAsync(new ReviewDTO { Content = "Great Place", Rating = 5, LocationId = 1 });

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Great Place", result.Content);
    }
}
