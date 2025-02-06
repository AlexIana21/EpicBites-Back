using Microsoft.AspNetCore.Mvc;
using Entities;
using EpicBites.Services;

namespace EpicBites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {

    private readonly IFavoriteService _serviceFavorite;

    public FavoriteController(IFavoriteService serviceFavorite)
        {
            _serviceFavorite = serviceFavorite;
        }

        [HttpGet]
        public async Task<ActionResult<List<Favorite>>> GetFavorite()
        {
            var favorite = await _serviceFavorite.GetAllAsync();
            return Ok(favorite);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetFavorite(int id)
        {
            var favorite = await _serviceFavorite.GetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound($"Favorito con ID {id} no encontrada.");
            }
            return Ok(favorite);
        }

        [HttpPost]
           public async Task<ActionResult<Favorite>> CreateFavorite(Favorite favorite)
        {
            var existingFavorite = await _serviceFavorite.GetByIdAsync(favorite.Id);
            if (existingFavorite != null)
            {
                return Conflict($"Esta receta ya la tienes guardada {favorite.Id}.");
            }

            await _serviceFavorite.AddAsync(favorite);
            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.Id }, favorite);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var favorite = await _serviceFavorite.GetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound($"Favorito con ID {id} no encontrada.");;
            }
            await _serviceFavorite.DeleteAsync(id);
            return NoContent();
        }
    }
}