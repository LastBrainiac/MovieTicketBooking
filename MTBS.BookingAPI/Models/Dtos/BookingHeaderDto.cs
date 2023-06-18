namespace MTBS.BookingAPI.Models.Dtos
{
    public class BookingHeaderDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<BookingDetailsDto> BookingDetails { get; set; }
    }
}
