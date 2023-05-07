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
            List<ViewingAreaRowDTO> seatList = GetFakeSeatList();

            _repository.Setup(p => p.GetFullSeatListAsync(movieId, screeningDate))
                .Returns(Task.FromResult(seatList));

            var bookingController = new BookingController(_repository.Object);

            var response = await bookingController.GetSeatListByMovieAndDate(movieId, screeningDate);

            Assert.Equal((int)HttpStatusCode.OK, (response.Result as OkObjectResult).StatusCode);
            Assert.Equal(seatList, ((ObjectResult)response.Result).Value as List<ViewingAreaRowDTO>);
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
