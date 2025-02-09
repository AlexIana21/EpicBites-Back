using EpicBites.Repositories;
using EpicBites.Service;
using EpicBites.Services;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("EpicBites");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'EpicBites' no está configurada.");
}

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>(provider => new UserRepository(connectionString));
builder.Services.AddScoped<IReviewRepository, ReviewRepository>(provider => new ReviewRepository(connectionString));
builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>(provider => new FavoriteRepository(connectionString));
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>(provider => new RecipeRepository(connectionString));
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>(provider => new IngredientRepository(connectionString));

// Servicios
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

// Controladores y JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración de CORS
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:5167")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});
// Middleware para Swagger y redirección HTTPS
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EpicBites API V1");
        c.RoutePrefix = string.Empty;  // Swagger estará disponible en la raíz
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
