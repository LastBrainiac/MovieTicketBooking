namespace MTBS.BookingAPI.Models.Dtos
{
    public class SeatDto
    {
        public int SeatNumber { get; set; }
        public bool Booked { get; set; }
        public bool IsSelected { get; set; }
    }
}
