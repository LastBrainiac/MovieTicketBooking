namespace MTBS.NotificationAPI.EventBusIntegration.Messages
{
    public class UserFinishedBooking
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<BasketItem> BookedMovies { get; set; }
    }
}
