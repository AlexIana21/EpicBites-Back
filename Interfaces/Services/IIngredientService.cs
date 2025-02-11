using Entities;

namespace EpicBites.Services
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient?> GetByIdAsync(int id);
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(int id);
        Task<Ingredient?> IngredientAsync();
    }
}