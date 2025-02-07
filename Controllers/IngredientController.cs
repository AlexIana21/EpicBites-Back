using Microsoft.AspNetCore.Mvc;
using EpicBites.Services;

namespace EpicBites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _serviceIngredient;

        public IngredientController(IIngredientService serviceIngredient)
        {
            _serviceIngredient = serviceIngredient;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingredient>>> GetIngredient()
        {
            var ingredients = await _serviceIngredient.GetAllAsync();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id)
        {
            var ingredient = await _serviceIngredient.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound($"Ingrediente con ID {id} no encontrado.");
            }
            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<ActionResult<Ingredient>> CreateIngredient(Ingredient ingredient)
        {
            var existingIngredient = await _serviceIngredient.GetByIdAsync(ingredient.Id);
            if (existingIngredient != null)
            {
                return Conflict($"Ya existe un ingrediente con el ID {ingredient.Id}.");
            }

            await _serviceIngredient.AddAsync(ingredient);
            return CreatedAtAction(nameof(_serviceIngredient), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, Ingredient updateIngredient)
        {
            var existingIngredient = await _serviceIngredient.GetByIdAsync(id);
            if (existingIngredient == null)
            {
                return NotFound($"Ingrediente con ID {id} no encontrado.");
            }
            existingIngredient.Name = updateIngredient.Name;
            existingIngredient.Category = updateIngredient.Category;
            existingIngredient.Calories = updateIngredient.Calories;
            existingIngredient.Allergen = updateIngredient.Allergen;
            existingIngredient.Image = updateIngredient.Image;
            await _serviceIngredient.UpdateAsync(existingIngredient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _serviceIngredient.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound($"Ingrediente con ID {id} no encontrado.");
            }
            await _serviceIngredient.DeleteAsync(id);
            return NoContent();
        }
    }
}
