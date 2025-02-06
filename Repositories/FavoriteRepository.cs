using Entities;
using MySql.Data.MySqlClient;


namespace EpicBites.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    { 
        private readonly string _connectionString;

        public FavoriteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Favorite>> GetAllAsync()
        {
            var favorites = new List<Favorite>();
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
                            var favorite = new Favorite
                            {
                                Id = reader.GetInt32(0),
                                Date = reader.GetDateTime(1),
                                UserId = reader.GetInt32(2),
                                RecipeId = reader.GetInt32(3)
                            }; 

                            favorites.Add(favorite);
                        }
                    }
                }
            }
            return favorites;
        }

        public async Task AddAsync(Favorite favorite)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Date", favorite.Date);
                    command.Parameters.AddWithValue("@UserId", favorite.UserId);
                    command.Parameters.AddWithValue("@RecipeId", favorite.RecipeId);

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

        public async Task<Favorite?> GetByIdAsync(int id)
        {
            Favorite favorite = null;

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
                            favorite = new Favorite
                            {
                                Id = reader.GetInt32(0),
                                Date = reader.GetDateTime(1),
                                UserId = reader.GetInt32(2),
                                RecipeId = reader.GetInt32(3)
                            }; 
                        }
                    }
                }
            }
            return favorite;
        }

        public async Task UpdateAsync(Favorite favorite)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", favorite.Date);
                    command.Parameters.AddWithValue("@UserId", favorite.UserId);
                    command.Parameters.AddWithValue("@RecipeId", favorite.RecipeId);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

   
}