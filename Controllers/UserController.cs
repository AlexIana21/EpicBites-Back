using Microsoft.AspNetCore.Mvc;
using EpicBites.Services;

namespace EpicBites.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _serviceUser;

        public UserController(IUserService serviceUser)
        {
            _serviceUser = serviceUser;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _serviceUser.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _serviceUser.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User con ID {id} no encontrado.");
            }
            var userDto = new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
            return Ok(userDto);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto login)
        {
            var user = await _serviceUser.LoginAsync(login.Email, login.Password);
            if (user == null)
            {
                return NotFound("Usuario no encontrado.");
            }

            var userDto = new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };

            return Ok(userDto);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            if (await _serviceUser.EmailExistsAsync(registerDto.Email))
            {
                return Conflict("El correo electrónico ya está registrado.");
            }

            if (await _serviceUser.UsernameExistsAsync(registerDto.Username))
            {
                return Conflict("El nombre de usuario ya está registrado.");
            }

            var user = await _serviceUser.RegisterAsync(registerDto.Username, registerDto.Email, registerDto.Password);

            var userDto = new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                Role = Constants.Enums.UserRole.User
            };
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, RegisterDto updateUser)
        {
            var existingUser = await _serviceUser.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User con ID {id} no encontrada.");
            }
            // Actualizar el user existente
            existingUser.Username = updateUser.Username;
            existingUser.Email = updateUser.Email;
            existingUser.Password = updateUser.Password;

            await _serviceUser.UpdateAsync(existingUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _serviceUser.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User con ID {id} no encontrado.");
            }

            await _serviceUser.DeleteAsync(id);
            return NoContent();
        }
    }
}
