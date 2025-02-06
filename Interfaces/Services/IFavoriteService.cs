using Entities;

namespace EpicBites.Services
{
    public interface IFavoriteService
    {
        Task<List<Favorite>> GetAllAsync();
        Task<Favorite?> GetByIdAsync(int id);
        Task AddAsync(Favorite favorite);
        Task UpdateAsync(Favorite favorite);
        Task DeleteAsync(int id);
    }
}