using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.SeedData;
using MTBS.MovieCatalogAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MovieDbSettings>(builder.Configuration.GetSection("MovieDatabase"));

builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000", "http://localhost:4200");
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.MapControllers();

DbInitializer.SeedMongoDbData(app);

app.Run();
