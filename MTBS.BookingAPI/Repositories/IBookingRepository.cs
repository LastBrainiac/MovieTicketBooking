using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.DTOs;

namespace MTBS.BookingAPI.Repositories
{
    public interface IBookingRepository
    {
        Task SaveBookingDataAsync(BookingHeader bookingHeader);
        Task<List<ReservedSeatDTO>> GetReservedSeatListAsync(string movieId, DateTime screeningDate);
    }
}
