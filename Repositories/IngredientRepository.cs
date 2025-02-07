using MySql.Data.MySqlClient;

namespace EpicBites.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string _connectionString;

        public IngredientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            var ingredients = new List<Ingredient>();
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
                            var ingredient = new Ingredient
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Category = Enum.Parse<Constants.Enums.Category>(reader.GetString(2)),
                                Calories = reader.GetInt32(3),
                                Allergen = reader.GetInt32(4),
                                Image = reader.GetString(5),
                            };
                            ingredients.Add(ingredient);
                        }
                    }
                }
            }
            return ingredients;
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Category", ingredient.Category);
                    command.Parameters.AddWithValue("@Calories", ingredient.Calories);
                    command.Parameters.AddWithValue("@Allergen", ingredient.Allergen);
                    command.Parameters.AddWithValue("@Image", ingredient.Image);
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

        public async Task<Ingredient?> GetByIdAsync(int id)
        {
            Ingredient ingredient = null;

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
                            ingredient = new Ingredient
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Category = Enum.Parse<Constants.Enums.Category>(reader.GetString(2)),
                                Calories = reader.GetInt32(3),
                                Allergen = reader.GetInt32(4),
                                Image = reader.GetString(5),
                            };
                        }
                    }
                }
            }
            return ingredient;
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", ingredient.Id);
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Category", ingredient.Category);
                    command.Parameters.AddWithValue("@Calories", ingredient.Calories);
                    command.Parameters.AddWithValue("@Allergen", ingredient.Allergen);
                    command.Parameters.AddWithValue("@Image", ingredient.Image);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}