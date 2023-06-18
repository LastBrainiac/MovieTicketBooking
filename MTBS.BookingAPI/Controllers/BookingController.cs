using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MTBS.BookingAPI.EventBusIntegration.Messages;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;
using MTBS.BookingAPI.Repositories;
using MTBS.EventBus;

namespace MTBS.BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;

        public BookingController(IBookingRepository bookingRepository, IMapper mapper, IConfiguration configuration, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _configuration = configuration;
            _rabbitMQMessageSender = rabbitMQMessageSender;
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
            bookingHeaderDto.Id = await _bookingRepository.SaveBookingDataAsync(_mapper.Map<BookingHeader>(bookingHeaderDto));

            var emailLogMessage = _mapper.Map<EmailLogMessage>(bookingHeaderDto);
            _rabbitMQMessageSender.PublishMessage(emailLogMessage, _configuration["EventBus:NotificationQueueName"]);

            return Ok();
        }
    }
}
