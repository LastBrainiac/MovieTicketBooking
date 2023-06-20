using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MTBS.BookingAPI.Controllers;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;
using MTBS.BookingAPI.Repositories;
using MTBS.EventBus;
using System.Net;

namespace APITests
{
    public class BookingAPITest
    {
        private readonly Mock<IBookingRepository> _repository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IRabbitMQMessageSender> _rabbitMQMessageSender;

        public BookingAPITest()
        {
            _repository = new Mock<IBookingRepository>();
            _mapper = new Mock<IMapper>();
            _configuration = new Mock<IConfiguration>();
            _rabbitMQMessageSender = new Mock<IRabbitMQMessageSender>();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetSeatListByMovieAndDate_ThenAPIReturnsExpectedResponse()
        {
            var movieId = "1111111";
            var screeningDate = new DateTime(2023, 05, 10);
            ViewingAreaRowDTO seatList = GetFakeSeatList();

            _repository.Setup(p => p.GetFullSeatListAsync(movieId, screeningDate))
                .Returns(Task.FromResult(seatList));

            var bookingController = new BookingController(_repository.Object, _mapper.Object, _configuration.Object, _rabbitMQMessageSender.Object);

            var response = await bookingController.GetSeatListByMovieAndDate(movieId, screeningDate);

            Assert.Equal((int)HttpStatusCode.OK, (response.Result as OkObjectResult).StatusCode);
            Assert.Equal(seatList, ((ObjectResult)response.Result).Value as ViewingAreaRowDTO);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingSaveBookingData_ThenAPIReturnsExpectedResponse()
        {
            var bookingHeaderDto = GetFakeBookingHeaderDto();

            _repository.Setup(p => p.SaveBookingDataAsync(_mapper.Object.Map<BookingHeader>(bookingHeaderDto)))
                .Returns(Task.FromResult(1));

            var bookingController = new BookingController(_repository.Object, _mapper.Object, _configuration.Object, _rabbitMQMessageSender.Object);

            var response = await bookingController.SaveBookingData(bookingHeaderDto);

            Assert.Equal((int)HttpStatusCode.OK, (response as OkResult).StatusCode);

        }

        private BookingHeaderDto GetFakeBookingHeaderDto()
        {
            return new BookingHeaderDto
            {
                FullName = "Name",
                EmailAddress = "email@address",
                PhoneNumber = "1234567890",
                Id = 1,
                BookingDetails = new List<BookingDetailsDto>()
                {
                    new BookingDetailsDto()
                    {
                        MovieId = "aaaaaaaaaaaa",
                        MovieTitle = "Title",
                        ScreeningDate = DateTime.Now,
                        TicketPrice = 2000,
                        TicketQuantity = 1,
                        ReservedSeats = new List<ReservedSeatDto>
                        {
                            new ReservedSeatDto()
                            {
                                Row = 1,
                                Seat = 1
                            }
                        }
                    }
                }
            };
        }

        private ViewingAreaRowDTO GetFakeSeatList()
        {
            return new ViewingAreaRowDTO()
            {
                Rows = new List<RowDto>
                {
                    new RowDto
                    {
                        RowNumber = 1,
                        Seats = new List<SeatDto>
                    {
                        new SeatDto
                        {
                            SeatNumber = 2,
                            Booked = true
                        },
                        new SeatDto
                        {
                            SeatNumber = 3,
                            Booked = true
                        }
                    }
                    }
                }
            };
        }
    }
}
