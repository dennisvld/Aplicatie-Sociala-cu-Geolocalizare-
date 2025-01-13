using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<bool> UserExistsAsync(string email);
}
