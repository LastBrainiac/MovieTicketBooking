using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace MTBS.BookingAPI.Extensions
{
    public static class HostExtensions
    {
        public static IHost UseAutoMigration<T>(this IHost app) where T : DbContext
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<T>();

            var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                    );

            retry.Execute(() => context.Database.Migrate());
            return app;
        }
    }
}
