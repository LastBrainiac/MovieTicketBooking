using Microsoft.AspNetCore.Mvc;
using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.Services;

namespace MTBS.MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            return Ok(await _movieService.GetAllMoviesAsync());
        }
    }
}
