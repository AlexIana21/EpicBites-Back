using Microsoft.AspNetCore.Mvc;
using EpicBites.Services;

namespace EpicBites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _serviceRecipe;

        public RecipeController(IRecipeService serviceRecipe)
        {
            _serviceRecipe = serviceRecipe;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetRecipe()
        {
            var recipes = await _serviceRecipe.GetAllAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _serviceRecipe.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound($"Receta con ID {id} no encontrado.");
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            var existingRecipe = await _serviceRecipe.GetByIdAsync(recipe.Id);
            if (existingRecipe != null)
            {
                return Conflict($"Ya existe una receta con el ID {recipe.Id}.");
            }

            await _serviceRecipe.AddAsync(recipe);
            return CreatedAtAction(nameof(_serviceRecipe), new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, Recipe updateRecipe)
        {
            var existingRecipe = await _serviceRecipe.GetByIdAsync(id);
            if (existingRecipe == null)
            {
                return NotFound($"Receta con ID {id} no encontrada.");
            }
            // Actualizar el user existente
            existingRecipe.Name = updateRecipe.Name;
            existingRecipe.Description = updateRecipe.Description;
            existingRecipe.Meal = updateRecipe.Meal;
            existingRecipe.Diet = updateRecipe.Diet;
            existingRecipe.Flavour = updateRecipe.Flavour;
            existingRecipe.Time = updateRecipe.Time;
            existingRecipe.Calories = updateRecipe.Calories;
            existingRecipe.Difficulty = updateRecipe.Difficulty;
            existingRecipe.Image = updateRecipe.Image;


            await _serviceRecipe.UpdateAsync(existingRecipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var user = await _serviceRecipe.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Receta con ID {id} no encontrado.");
            }

            await _serviceRecipe.DeleteAsync(id);
            return NoContent();
        }
    }
}
