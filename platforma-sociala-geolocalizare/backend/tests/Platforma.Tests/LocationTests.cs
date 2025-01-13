using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LocationTests
{
    [Fact]
    public async Task GetAllLocations_ReturnsLocations()
    {
        // Arrange
        var mockRepo = new Mock<ILocationRepository>();
        mockRepo.Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(new List<Location> { new Location { Id = 1, Name = "Test Location" } });
        var service = new LocationService(mockRepo.Object);

        // Act
        var locations = await service.GetAllLocationsAsync();

        // Assert
        Assert.Single(locations);
        Assert.Equal("Test Location", locations.First().Name);
    }
}
