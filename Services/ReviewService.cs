using Entities;
using EpicBites.Repositories;
using EpicBites.Services;

namespace EpicBites.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;

        }

        public async Task<List<Review>> GetAllAsync()
        {
            return await _reviewRepository.GetAllAsync();
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Review review)
        {
            await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateAsync(Review review)
        {
            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                // Manejar el caso de no encontrado
            }
            await _reviewRepository.DeleteAsync(id);
        }
    }
}