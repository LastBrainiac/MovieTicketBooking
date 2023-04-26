using MTBS.NotificationAPI.EventBusIntegration.Messages;

namespace MTBS.NotificationAPI.Repositories
{
    public interface INotificationRepository
    {
        Task CreateLogEntry(EmailLogMessage logMessage);
    }
}
