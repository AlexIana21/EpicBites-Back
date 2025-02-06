using Entities;
using MySql.Data.MySqlClient;


namespace EpicBites.Repositories
{
    public class ReviewRepository : IReviewRepository
    { 
        private readonly string _connectionString;

        public ReviewRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Review>> GetAllAsync()
        {
            var reviews = new List<Review>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var review = new Review
                            {
                                Id = reader.GetInt32(0),
                                Text = reader.GetString(1),
                                Date = reader.GetDateTime(2),
                                Score = reader.GetInt32(3),
                                UserId = reader.GetInt32(4),
                                RecipeId = reader.GetInt32(5)
                            }; 

                            reviews.Add(review);
                        }
                    }
                }
            }
            return reviews;
        }

        public async Task AddAsync(Review review)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Text", review.Text);
                    command.Parameters.AddWithValue("@Date", review.Date);
                    command.Parameters.AddWithValue("@Score", review.Score);
                    command.Parameters.AddWithValue("@UserId", review.UserId);
                    command.Parameters.AddWithValue("@RecipeId", review.RecipeId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
               await connection.OpenAsync();

               string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
               
            }
        }

        public async Task<Review?> GetByIdAsync(int id)
        {
            Review review = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            review = new Review
                            {
                                Id = reader.GetInt32(0),
                                Text = reader.GetString(1),
                                Date = reader.GetDateTime(2),
                                Score = reader.GetInt32(3),
                                UserId = reader.GetInt32(4),
                                RecipeId = reader.GetInt32(5)
                            }; 
                        }
                    }
                }
            }
            return review;
        }

        public async Task UpdateAsync(Review review)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Text", review.Text);
                    command.Parameters.AddWithValue("@Date", review.Date);
                    command.Parameters.AddWithValue("@Score", review.Score);
                    command.Parameters.AddWithValue("@UserId", review.UserId);
                    command.Parameters.AddWithValue("@RecipeId", review.RecipeId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

   
}