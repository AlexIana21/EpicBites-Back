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
        public async Task<ActionResult<RecipeDto>> GetRecipe(int id)
        {
            var recipe = await _serviceRecipe.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound($"Receta con ID {id} no encontrado.");
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<RecipeDto>> CreateRecipe(RecipeDto recipeDto)
        {
            var recipe = new Recipe
            {
                Name = recipeDto.Name,
                Description = recipeDto.Description,
                Meal = recipeDto.Meal,
                Diet = recipeDto.Diet,
                Flavour = recipeDto.Flavour,
                Time = recipeDto.Time,
                Calories = recipeDto.Calories,
                Difficulty = recipeDto.Difficulty,
                Image = recipeDto.Image
            };

            await _serviceRecipe.AddAsync(recipe);
            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipeDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(int id, RecipeDto updateRecipe)
        {
            var existingRecipe = await _serviceRecipe.GetByIdAsync(id);
            if (existingRecipe == null)
            {
                return NotFound($"Receta con ID {id} no encontrada.");
            }

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
            var recipe = await _serviceRecipe.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound($"Receta con ID {id} no encontrada.");
            }

            await _serviceRecipe.DeleteAsync(id);
            return NoContent();
        }
    }
}
