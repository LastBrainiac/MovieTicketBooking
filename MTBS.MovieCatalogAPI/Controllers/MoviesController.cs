using Microsoft.AspNetCore.Mvc;
using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.Services;

namespace MTBS.MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<Movie>> GetAllMovies()
        {
            return await _movieService.GetAllMoviesAsync();
        }
    }
}
