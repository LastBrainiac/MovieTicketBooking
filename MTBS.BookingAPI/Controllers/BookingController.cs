using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MTBS.BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<Object>> GetBookedSeatList(string movieId, DateOnly screeningDate, TimeOnly screeningTime)
        {
            return Ok();
        }
    }
}
