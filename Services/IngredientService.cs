using Entities;
using EpicBites.Repositories;
using EpicBites.Services;

namespace EpicBites.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;

        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }

        public async Task<Ingredient?> GetByIdAsync(int id)
        {
            return await _ingredientRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            await _ingredientRepository.AddAsync(ingredient);
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            await _ingredientRepository.UpdateAsync(ingredient);
        }

        public async Task DeleteAsync(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id);
            if (ingredient == null)
            {
                // Manejar el caso de no encontrado
            }
            await _ingredientRepository.DeleteAsync(id);
        }

        public async Task<Ingredient?> IngredientAsync()
        {
            return await _ingredientRepository.IngredientAsync();
        }
    }
}