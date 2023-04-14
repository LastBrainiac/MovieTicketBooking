using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MTBS.MovieCatalogAPI.Models;
using System.Text.Json;

namespace MTBS.MovieCatalogAPI.SeedData
{
    public class DbInitializer
    {
        private static IMongoCollection<Movie> _collection;

        public static void SeedMongoDbData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var movieDbSettings = services.GetRequiredService<IOptions<MovieDbSettings>>().Value;

            var mongoClient = new MongoClient(movieDbSettings.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(movieDbSettings.DatabaseName);
            _collection = mongoDb.GetCollection<Movie>(movieDbSettings.MoviesCollectionName);
            if (_collection.EstimatedDocumentCount() == 0)
            {
                var movieData = File.ReadAllText("SeedData/moviedata.json");
                var movieList = JsonSerializer.Deserialize<List<Movie>>(movieData);
                _collection.InsertMany(movieList);
            }
        }
    }
}
