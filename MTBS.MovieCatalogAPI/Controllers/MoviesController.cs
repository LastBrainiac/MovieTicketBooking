using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTBS.MovieCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("GetAllMovies");
        }
    }
}
