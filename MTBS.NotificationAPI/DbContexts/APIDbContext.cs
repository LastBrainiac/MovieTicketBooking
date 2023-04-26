using Microsoft.EntityFrameworkCore;
using MTBS.NotificationAPI.Models;

namespace MTBS.NotificationAPI.DbContexts
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }

        public DbSet<EmailLog> EmailLogs { get; set; }
    }
}
