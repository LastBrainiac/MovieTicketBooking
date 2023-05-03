using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTBS.BookingAPI.Models.DTOs;
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
        public async Task<ActionResult<List<ReservedSeatDTO>>> GetBookedSeatList(string movieId, DateTime screeningDate)
        {
            var seatList = await _bookingRepository.GetReservedSeatListAsync(movieId, screeningDate);
            return Ok(seatList);
        }
    }
}
