namespace MTBS.NotificationAPI.EventBusIntegration.Messages
{
    public class EmailLogMessage
    {
        public int BookingId { get; set; } = 9999;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
    }
}
