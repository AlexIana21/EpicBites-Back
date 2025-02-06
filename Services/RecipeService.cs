
using EpicBites.Repositories;
using EpicBites.Services;

namespace EpicBites.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            return await _recipeRepository.GetAllAsync();
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _recipeRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Recipe recipe)
        {
            await _recipeRepository.AddAsync(recipe);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            await _recipeRepository.UpdateAsync(recipe);
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _recipeRepository.GetByIdAsync(id);
            if (user == null)
            {
                // Manejar el caso de no encontrado
            }
            await _recipeRepository.DeleteAsync(id);
        }
    }
}
