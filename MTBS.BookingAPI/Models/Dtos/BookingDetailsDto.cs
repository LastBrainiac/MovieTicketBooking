namespace MTBS.BookingAPI.Models.Dtos
{
    public class BookingDetailsDto
    {
        public string MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int TicketQuantity { get; set; }
        public int TicketPrice { get; set; }
        public DateTime ScreeningDate { get; set; }
        public List<ReservedSeatDto> ReservedSeats { get; set; }
    }
}
