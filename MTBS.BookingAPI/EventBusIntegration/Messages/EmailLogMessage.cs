namespace MTBS.BookingAPI.EventBusIntegration.Messages
{
    public class EmailLogMessage
    {
        public int BookingId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Created { get; set; }
    }
}
