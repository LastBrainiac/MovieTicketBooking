using MTBS.MovieCatalogAPI.Models;

namespace MTBS.MovieCatalogAPI.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
    }
}
