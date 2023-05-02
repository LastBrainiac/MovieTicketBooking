using Microsoft.EntityFrameworkCore;
using MTBS.BookingAPI.DbContexts;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.DTOs;

namespace MTBS.BookingAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly APIDbContext _dbContext;

        public BookingRepository(DbContextOptions<APIDbContext> contextOptions)
        {
            _dbContext = new APIDbContext(contextOptions);
        }

        public async Task<List<ReservedSeatDTO>> GetReservedSeatListAsync(string movieId, DateTime screeningDate)
        {
            throw new NotImplementedException();
        }

        public async Task SaveBookingDataAsync(BookingHeader bookingHeader)
        {
            _dbContext.BookingHeaders.Add(bookingHeader);
            await _dbContext.SaveChangesAsync();
        }
    }
}
