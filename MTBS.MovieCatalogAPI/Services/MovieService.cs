using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MTBS.MovieCatalogAPI.Models;

namespace MTBS.MovieCatalogAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMongoCollection<Movie> _collection;

        public MovieService(IOptions<MovieDbSettings> movieDbSettings)
        {
            var mongoClient = new MongoClient(movieDbSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(movieDbSettings.Value.DatabaseName);
            _collection = mongoDb.GetCollection<Movie>(movieDbSettings.Value.MoviesCollectionName);
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
