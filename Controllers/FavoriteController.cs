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
        public async Task<ActionResult<FavoriteDto>> GetFavorite(int id)
        {
            var favorite = await _serviceFavorite.GetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound($"Favorito con ID {id} no encontrada.");
            }
            return Ok(favorite);
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteDto>> CreateFavorite(FavoriteDto favoriteDto)
        {
            var favorite = new Favorite
            {
                Date = favoriteDto.Date,
                UserId = favoriteDto.UserId,
                RecipeId = favoriteDto.RecipeId,
            };

            await _serviceFavorite.AddAsync(favorite);
            return CreatedAtAction(nameof(_serviceFavorite), new { id = favorite.Id }, favoriteDto);
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