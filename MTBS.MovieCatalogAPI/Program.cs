using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.SeedData;
using MTBS.MovieCatalogAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<MovieDbSettings>(builder.Configuration.GetSection("MovieDatabase"));

builder.Services.AddSingleton<MovieService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

DbInitializer.SeedMongoDbData(app);

app.Run();
