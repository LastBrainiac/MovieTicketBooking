using MTBS.EventBus;

namespace MTBS.NotificationAPI.EventBusIntegration.Messages
{
    public class EmailLogMessage : BaseMessage
    {
        public int BookingId { get; set; }
        public string EmailAddress { get; set; }
    }
}
