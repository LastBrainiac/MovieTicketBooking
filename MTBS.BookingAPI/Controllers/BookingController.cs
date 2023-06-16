using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;
using MTBS.BookingAPI.Repositories;

namespace MTBS.BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
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

        [HttpPost]
        public async Task<ActionResult> SaveBookingData(BookingHeaderDto bookingHeaderDto)
        {
            await _bookingRepository.SaveBookingDataAsync(_mapper.Map<BookingHeader>(bookingHeaderDto));
            return Ok();
        }
    }
}
