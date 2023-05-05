namespace MTBS.BookingAPI.Models.Dtos
{
    public class ViewingAreaRowDTO
    {
        public int RowNumber { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
