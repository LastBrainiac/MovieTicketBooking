namespace MTBS.NotificationAPI.EventBusIntegration.Messages
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public int TicketQuantity { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime ScreeningDate { get; set; }
        public List<Seat> BookedSeats { get; set; }
    }
}
