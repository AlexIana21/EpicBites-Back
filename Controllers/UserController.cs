using Microsoft.AspNetCore.Mvc;
using EpicBites.Services;

namespace EpicBites.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _serviceUser.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User con ID {id} no encontrado.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var existingUser = await _serviceUser.GetByIdAsync(user.Id);
            if (existingUser != null)
            {
                return Conflict($"Ya existe un admin con el ID {user.Id}.");
            }
            await _serviceUser.AddAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updateUser)
        {
            var existingUser = await _serviceUser.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound($"User con ID {id} no encontrada.");
            }
            // Actualizar el user existente
            existingUser.Email = updateUser.Email;
            existingUser.Password = updateUser.Password;
            existingUser.Role = updateUser.Role;


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
