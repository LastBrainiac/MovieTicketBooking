using EventBusBase.Events;
using MTBS.BasketAPI.Models;

namespace MTBS.BasketAPI.EventBusIntegration.Events
{
    public class UserFinishedBookingIntegrationEvent : IntegrationEvent
    {
        public UserFinishedBookingIntegrationEvent(string fullName, string emailAddress, string phoneNumber, CustomerBasket basket)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Basket = basket;
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerBasket Basket { get; set; }
    }
}
