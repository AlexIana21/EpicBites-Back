namespace EpicBites.Repositories

{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<User?> LoginAsync(string email, string password);
        Task<User?> RegisterAsync(string username, string email, string password);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> UsernameExistsAsync(string username);

    }
}
