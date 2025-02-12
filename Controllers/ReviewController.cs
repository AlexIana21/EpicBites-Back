using Microsoft.AspNetCore.Mvc;
using Entities;
using EpicBites.Services;

namespace EpicBites.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {

    private readonly IReviewService _serviceReview;

    public ReviewController(IReviewService serviceReview)
        {
            _serviceReview = serviceReview;
        }

        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetReview()
        {
            var reviews = await _serviceReview.GetAllAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReview(int id)
        {
            var review = await _serviceReview.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewDto>> CreateReview(ReviewDto reviewDto)
        {
            var review = new Review
            {
                Text = reviewDto.Text,
                Date = reviewDto.Date,
                Score = reviewDto.UserId,
                RecipeId = reviewDto.RecipeId,
            };

            await _serviceReview.AddAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, reviewDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _serviceReview.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            await _serviceReview.DeleteAsync(id);
            return NoContent();
        }
    }
}