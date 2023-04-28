using Microsoft.EntityFrameworkCore;

namespace MTBS.BookingAPI.DbContexts
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }
    }
}
