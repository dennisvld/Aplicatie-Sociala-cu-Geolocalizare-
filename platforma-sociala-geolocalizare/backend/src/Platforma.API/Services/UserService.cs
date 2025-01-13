public interface IUserService
{
    Task<ServiceResponse<string>> RegisterAsync(UserRegisterDTO userDto);
    Task<ServiceResponse<string>> LoginAsync(UserLoginDTO userDto);
}

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ServiceResponse<string>> RegisterAsync(UserRegisterDTO userDto)
    {
        if (await _repository.UserExistsAsync(userDto.Email))
            return new ServiceResponse<string> { Success = false, Message = "User already exists" };

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            PasswordHash = hashedPassword
        };

        await _repository.AddAsync(user);

        return new ServiceResponse<string> { Success = true, Message = "User registered successfully" };
    }

    public async Task<ServiceResponse<string>> LoginAsync(UserLoginDTO userDto)
    {
        var user = await _repository.GetByEmailAsync(userDto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
            return new ServiceResponse<string> { Success = false, Message = "Invalid credentials" };

        var token = _tokenService.GenerateToken(user);
        return new ServiceResponse<string> { Success = true, Data = token };
    }
}
