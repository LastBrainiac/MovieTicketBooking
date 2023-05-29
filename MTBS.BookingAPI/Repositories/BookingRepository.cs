using Microsoft.EntityFrameworkCore;
using MTBS.BookingAPI.DbContexts;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;

namespace MTBS.BookingAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly APIDbContext _dbContext;

        public BookingRepository(DbContextOptions<APIDbContext> contextOptions)
        {
            _dbContext = new APIDbContext(contextOptions);
        }

        public async Task<ViewingAreaRowDTO> GetFullSeatListAsync(string movieId, DateTime screeningDate)
        {
            var bookedSeats = await _dbContext.BookingDetails
                .Join(_dbContext.ReservedSeats, a => a.Id, b => b.BookingDetailsId, (a, b) => new { a.MovieId, a.ScreeningDate, b.RowNumber, b.SeatNumber })
                .Where(p => p.MovieId == movieId && p.ScreeningDate == screeningDate).ToListAsync();

            var viewingArea = new ViewingAreaRowDTO
            {
                Rows = Enumerable.Range(1, 10).Select(row => new RowDto
                {
                    RowNumber = row,
                    Seats = Enumerable.Range(1, 12).Select(seatNumber => new SeatDto
                    {
                        SeatNumber = seatNumber,
                        Booked = bookedSeats.Any(p => p.RowNumber == row && p.SeatNumber == seatNumber),
                        IsSelected = false
                    }).ToList()
                }).ToList()                
            };

            return viewingArea;
        }

        public async Task SaveBookingDataAsync(BookingHeader bookingHeader)
        {
            _dbContext.BookingHeaders.Add(bookingHeader);
            await _dbContext.SaveChangesAsync();
        }
    }
}
