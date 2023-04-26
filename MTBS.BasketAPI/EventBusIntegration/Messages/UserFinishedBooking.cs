using MTBS.BasketAPI.Models;
using MTBS.EventBus;

namespace MTBS.BasketAPI.EventBusIntegration.Messages
{
    public class UserFinishedBooking : BaseMessage
    {
        public UserFinishedBooking(string fullName, string emailAddress, string phoneNumber, CustomerBasket basket)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            BookedMovies = basket.Items;
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }        
        public List<BasketItem> BookedMovies { get; set; }
    }
}
