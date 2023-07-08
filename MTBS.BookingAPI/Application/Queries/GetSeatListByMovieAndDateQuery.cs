using MediatR;
using MTBS.BookingAPI.Models.Dtos;

namespace MTBS.BookingAPI.Application.Queries
{
    public class GetSeatListByMovieAndDateQuery : IRequest<ViewingAreaRowDTO>
    {
        public string MovieId { get; set; }
        public DateTime ScreeningDate { get; set; }
    }
}
