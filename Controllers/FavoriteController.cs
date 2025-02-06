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
        public async Task<ActionResult<List<Favorite>>> GetReview()
        {
            var favorite = await _serviceFavorite.GetAllAsync();
            return Ok(favorite);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Favorite>> GetReview(int id)
        {
            var favorite = await _serviceFavorite.GetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            return Ok(favorite);
        }

        [HttpPost]
        public async Task<ActionResult<Favorite>> CreateReview(Favorite favorite)
        {
            await _serviceFavorite.AddAsync(favorite);
            return CreatedAtAction(nameof(GetReview), new { id = favorite.Id }, favorite);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var favorite = await _serviceFavorite.GetByIdAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }
            await _serviceFavorite.DeleteAsync(id);
            return NoContent();
        }
    }
}