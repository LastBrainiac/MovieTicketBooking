using AutoMapper;
using MTBS.NotificationAPI.EventBusIntegration.Messages;
using MTBS.NotificationAPI.Models;

namespace MTBS.NotificationAPI.Helpers
{
    public class LogTextValueResolver : IValueResolver<EmailLogMessage, EmailLog, string>
    {
        public string Resolve(EmailLogMessage source, EmailLog destination, string destMember, ResolutionContext context)
        {
            return source.BookingId > 0 ? $"Ticket booking - #{source.BookingId} has been created successfully." : null;
        }
    }
}
