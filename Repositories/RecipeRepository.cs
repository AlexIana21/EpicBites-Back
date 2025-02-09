using MySql.Data.MySqlClient;


namespace EpicBites.Repositories
{
    public class RecipeRepository : IRecipeRepository
    { 
        private readonly string _connectionString;

        public RecipeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Recipe>> GetAllAsync()
        {
            var recipes = new List<Recipe>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Name, Description, Meal, Diet, Flavour, Time, Calories, Difficulty, Image FROM Recipe";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var recipe = new Recipe
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Meal = Enum.Parse<Constants.Enums.Meal>(reader.GetString(3)),
                                Diet = Enum.Parse<Constants.Enums.Diet>(reader.GetString(4)),
                                Flavour = Enum.Parse<Constants.Enums.Flavour>(reader.GetString(5)),
                                Time = reader.GetInt32(6),
                                Calories = reader.GetInt32(7),
                                Difficulty = Enum.Parse<Constants.Enums.Difficulty>(reader.GetString(8)),
                                Image = reader.GetString(9),
                                //UserRole.GetValue(reader.GetString(3))
                            };
                            recipes.Add(recipe);
                        }
                    }
                }
            }
            return recipes;
        }

        public async Task AddAsync(Recipe recipe)
        {
            using (var connection = new MySqlConnection (_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                INSERT INTO Recipe (Name, Description, Meal, Diet, Flavour, Time, Calories, Difficulty, Image) 
                VALUES (@Name, @Description, @Meal, @Diet, @Flavour, @Time, @Calories, @Difficulty, @Image)";

                using (var command = new MySqlCommand(query, connection)){
                    command.Parameters.AddWithValue("@Name", recipe.Name);
                    command.Parameters.AddWithValue("@Description", recipe.Description);
                    command.Parameters.AddWithValue("@Meal", recipe.Meal);
                    command.Parameters.AddWithValue("@Diet", recipe.Diet);
                    command.Parameters.AddWithValue("@Flavour", recipe.Flavour);
                    command.Parameters.AddWithValue("@Time", recipe.Time);
                    command.Parameters.AddWithValue("@Calories", recipe.Calories);
                    command.Parameters.AddWithValue("@Difficulty", recipe.Difficulty);
                    command.Parameters.AddWithValue("@Image", recipe.Image);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
               await connection.OpenAsync();

               string query = "DELETE FROM Recipe WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
               
            }
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            Recipe recipe = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Name, Description, Meal, Diet, Flavour, Time, Calories, Difficulty, Image FROM Recipe WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            recipe = new Recipe
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Meal = Enum.Parse<Constants.Enums.Meal>(reader.GetString(3)),
                                Diet = Enum.Parse<Constants.Enums.Diet>(reader.GetString(4)),
                                Flavour = Enum.Parse<Constants.Enums.Flavour>(reader.GetString(5)),
                                Time = reader.GetInt32(6),
                                Calories = reader.GetInt32(7),
                                Difficulty = Enum.Parse<Constants.Enums.Difficulty>(reader.GetString(8)),
                                Image = reader.GetString(9),
                            };
                        }
                    }
                }
            }
            return recipe;
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                UPDATE Recipe 
                SET Name = @Name, 
                    Description = @Description, 
                    Meal = @Meal, 
                    Diet = @Diet, 
                    Flavour = @Flavour, 
                    Time = @Time, 
                    Calories = @Calories, 
                    Difficulty = @Difficulty, 
                    Image = @Image 
                WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", recipe.Name);
                    command.Parameters.AddWithValue("@Description", recipe.Description);
                    command.Parameters.AddWithValue("@Meal", recipe.Meal);
                    command.Parameters.AddWithValue("@Diet", recipe.Diet);
                    command.Parameters.AddWithValue("@Flavour", recipe.Flavour);
                    command.Parameters.AddWithValue("@Time", recipe.Time);
                    command.Parameters.AddWithValue("@Calories", recipe.Calories);
                    command.Parameters.AddWithValue("@Difficulty", recipe.Difficulty);
                    command.Parameters.AddWithValue("@Image", recipe.Image);
                    
                    command.Parameters.AddWithValue("@Id", recipe.Id);


                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }
}