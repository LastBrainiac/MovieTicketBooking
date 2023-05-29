namespace MTBS.BookingAPI.Models.Dtos
{
    public class RowDto
    {
        public int RowNumber { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
