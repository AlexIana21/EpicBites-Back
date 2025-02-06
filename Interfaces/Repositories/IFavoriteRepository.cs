using Entities;

namespace EpicBites.Repositories
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetAllAsync();
        Task<Favorite?> GetByIdAsync(int id);
        Task AddAsync(Favorite favorite);
        Task UpdateAsync(Favorite favorite);
        Task DeleteAsync(int id);
    }
}