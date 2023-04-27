using Microsoft.EntityFrameworkCore;
using MTBS.NotificationAPI.DbContexts;
using MTBS.NotificationAPI.EventBusIntegration.Messages;
using MTBS.NotificationAPI.Models;

namespace MTBS.NotificationAPI.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly APIDbContext _dbContext;
        public NotificationRepository(DbContextOptions<APIDbContext> contextOptions)
        {
            _dbContext = new APIDbContext(contextOptions);
        }

        public async Task CreateLogEntry(EmailLogMessage logMessage)
        {
            EmailLog emailLog = new EmailLog
            {
                EmailAddress = logMessage.EmailAddress,
                EmailSent = logMessage.Created,
                LogText = $"Ticket booking - #{logMessage.BookingId} has been created successfully."
            };
            _dbContext.EmailLogs.Add(emailLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
