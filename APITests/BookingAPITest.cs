using Microsoft.AspNetCore.Mvc;
using MTBS.BasketAPI.Models;
using MTBS.BookingAPI.Controllers;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;
using MTBS.BookingAPI.Repositories;
using System.Net;

namespace APITests
{
    public class BookingAPITest
    {
        private readonly Mock<IBookingRepository> _repository;

        public BookingAPITest()
        {
            _repository = new Mock<IBookingRepository>();
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetSeatListByMovieAndDate_ThenAPIReturnsExpectedResponse()
        {
            var movieId = "1111111";
            var screeningDate = new DateTime(2023, 05, 10);
            BookingHeader bookingHeader = GetFakeBookingHeader(movieId, screeningDate);
            List<ViewingAreaRowDTO> seatList = GetFakeSeatList();

            _repository.Setup(p => p.SaveBookingDataAsync(bookingHeader))
                .Returns(Task.FromResult(typeof(Task)));

            _repository.Setup(p => p.GetFullSeatListAsync(movieId, screeningDate))
                .Returns(Task.FromResult(seatList));

            var bookingController = new BookingController(_repository.Object);

            var response = await bookingController.GetSeatListByMovieAndDate(movieId, screeningDate);

            Assert.Equal((response.Result as OkObjectResult).StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal(((ObjectResult)response.Result).Value as List<ViewingAreaRowDTO>, seatList);
        }

        private BookingHeader GetFakeBookingHeader(string movieId, DateTime screeningDate)
        {
            return new BookingHeader
            {
                FullName = "XYZ",
                EmailAddress = "xyz@gmail.com",
                PhoneNumber = "1234567890",
                BookingDetails = new List<BookingDetails>
                {
                    new BookingDetails
                    {
                        MovieId = movieId,
                        MovieTitle = "Great Movie",
                        ScreeningDate = screeningDate,
                        TicketPrice = 2500,
                        TicketQuantity = 2,
                        ReservedSeats = new List<ReservedSeat>
                        {
                            new ReservedSeat
                            {
                                RowNumber = 1,
                                SeatNumber = 2,
                            },
                            new ReservedSeat
                            {
                                RowNumber = 1,
                                SeatNumber = 3,
                            }
                        }
                    }
                }
            };
        }

        private List<ViewingAreaRowDTO> GetFakeSeatList()
        {
            return new List<ViewingAreaRowDTO>()
            {
                new ViewingAreaRowDTO
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
            };
        }
    }
}
