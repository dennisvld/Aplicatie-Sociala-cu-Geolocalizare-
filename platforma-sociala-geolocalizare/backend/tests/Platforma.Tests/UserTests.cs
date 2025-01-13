using Xunit;
using Moq;
using System.Threading.Tasks;

public class UserTests
{
    [Fact]
    public async Task Register_ExistingUser_ReturnsError()
    {
        // Arrange
        var mockRepo = new Mock<IUserRepository>();
        mockRepo.Setup(repo => repo.UserExistsAsync(It.IsAny<string>())).ReturnsAsync(true);
        var service = new UserService(mockRepo.Object, new Mock<ITokenService>().Object);

        // Act
        var response = await service.RegisterAsync(new UserRegisterDTO { Email = "test@test.com", Password = "password" });

        // Assert
        Assert.False(response.Success);
        Assert.Equal("User already exists", response.Message);
    }
}
