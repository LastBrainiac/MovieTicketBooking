using Microsoft.AspNetCore.Mvc;
using MTBS.BookingAPI.Models.Dtos;
using MTBS.BookingAPI.Repositories;

namespace MTBS.BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ViewingAreaRowDTO>> GetSeatListByMovieAndDate(string movieId, DateTime screeningDate)
        {
            if (string.IsNullOrEmpty(movieId) || screeningDate == DateTime.MinValue)
            {
                return BadRequest();
            }
            var viewingArea = await _bookingRepository.GetFullSeatListAsync(movieId, screeningDate);
            return Ok(viewingArea);
        }
    }
}
