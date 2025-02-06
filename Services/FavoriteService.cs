using Entities;
using EpicBites.Repositories;
using EpicBites.Services;

namespace EpicBites.Service
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;

        }

        public async Task<List<Favorite>> GetAllAsync()
        {
            return await _favoriteRepository.GetAllAsync();
        }

        public async Task<Favorite?> GetByIdAsync(int id)
        {
            return await _favoriteRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Favorite favorite)
        {
            await _favoriteRepository.AddAsync(favorite);
        }

        public async Task UpdateAsync(Favorite favorite)
        {
            await _favoriteRepository.UpdateAsync(favorite);
        }

        public async Task DeleteAsync(int id)
        {
            var favorite = await _favoriteRepository.GetByIdAsync(id);
            if (favorite == null)
            {
                // Manejar el caso de no encontrado
            }
            await _favoriteRepository.DeleteAsync(id);
        }
    }
}