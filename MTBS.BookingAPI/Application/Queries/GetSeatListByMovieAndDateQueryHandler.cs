using MediatR;
using MTBS.BookingAPI.Models.Dtos;
using MTBS.BookingAPI.Repositories;

namespace MTBS.BookingAPI.Application.Queries
{
    public class GetSeatListByMovieAndDateQueryHandler : IRequestHandler<GetSeatListByMovieAndDateQuery, ViewingAreaRowDTO>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetSeatListByMovieAndDateQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<ViewingAreaRowDTO> Handle(GetSeatListByMovieAndDateQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetFullSeatListAsync(request.MovieId, request.ScreeningDate);
        }
    }
}
