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

        public async Task CreateLogEntry(EmailLog logMessage)
        {            
            _dbContext.EmailLogs.Add(logMessage);
            await _dbContext.SaveChangesAsync();
        }
    }
}
