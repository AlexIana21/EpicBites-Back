
using EpicBites.Repositories;
using EpicBites.Services;

namespace EpicBites.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                // Manejar el caso de no encontrado
            }
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            return await _userRepository.LoginAsync(email, password);
        }

        public async Task<User?> RegisterAsync(string username, string email, string password)
        {
            return await _userRepository.RegisterAsync(username, email, password);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _userRepository.EmailExistsAsync(email);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _userRepository.UsernameExistsAsync(username);
        }
    }
}
