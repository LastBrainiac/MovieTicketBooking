using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MTBS.MovieCatalogAPI.Models;
using MTBS.MovieCatalogAPI.Models.Dtos;
using MTBS.MovieCatalogAPI.Services;

namespace MTBS.MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(_mapper.Map<List<MovieDto>>(movies));
        }
    }
}
