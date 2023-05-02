using Microsoft.EntityFrameworkCore;
using MTBS.BookingAPI.Models;

namespace MTBS.BookingAPI.DbContexts
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<BookingHeader> BookingHeaders { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<ReservedSeat> ReservedSeats { get; set; }
    }
}
