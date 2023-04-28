using MTBS.EventBus;

namespace MTBS.BookingAPI.EventBusIntegration.Messages
{
    public class UserFinishedBooking : BaseMessage
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<BasketItem> BookedMovies { get; set; }
    }
}
