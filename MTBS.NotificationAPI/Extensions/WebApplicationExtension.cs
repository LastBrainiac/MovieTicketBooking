using Microsoft.EntityFrameworkCore;
using MTBS.NotificationAPI.DbContexts;

namespace MTBS.NotificationAPI.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication UseAutoMigration(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<APIDbContext>();
            context.Database.MigrateAsync().GetAwaiter().GetResult();
            return app;
        }
    }
}
