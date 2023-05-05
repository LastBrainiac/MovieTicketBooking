using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;

namespace MTBS.BookingAPI.Repositories
{
    public interface IBookingRepository
    {
        Task SaveBookingDataAsync(BookingHeader bookingHeader);
        Task<List<ViewingAreaRowDTO>> GetFullSeatListAsync(string movieId, DateTime screeningDate);
    }
}
