using EpicBites.Repositories;
using EpicBites.Service;
using EpicBites.Services;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString(""); //Poner la nuestra que sea necesaria.

builder.Services.AddScoped<IUserRepository, UserRepository>(provider =>
new UserRepository(connectionString));

builder.Services.AddScoped<IReviewRepository, ReviewRepository>(provider =>
new ReviewRepository(connectionString));

builder.Services.AddScoped<IFavoriteRepository, FavoriteRepository>(provider =>
new FavoriteRepository(connectionString));

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>(provider =>
new RecipeRepository(connectionString));

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>(provider =>
new IngredientRepository(connectionString));

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

var app = builder.Build();

app.UseCors(configurePolicy: policy =>
{
    // policy.WithOrigins("*","https://localhost","http://localhost");
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
