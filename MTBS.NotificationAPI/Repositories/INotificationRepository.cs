using MTBS.NotificationAPI.Models;

namespace MTBS.NotificationAPI.Repositories
{
    public interface INotificationRepository
    {
        Task CreateLogEntry(EmailLog logMessage);
    }
}
