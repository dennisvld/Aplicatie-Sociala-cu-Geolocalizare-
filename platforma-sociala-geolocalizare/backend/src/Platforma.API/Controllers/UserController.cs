using Microsoft.AspNetCore.Mvc;
using Platforma.API.DTOs;
using Platforma.API.Services;

namespace Platforma.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userDto)
        {
            var result = await _userService.RegisterAsync(userDto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userDto)
        {
            var result = await _userService.LoginAsync(userDto);
            if (!result.Success)
                return Unauthorized(result.Message);

            return Ok(result);
        }
    }
}
