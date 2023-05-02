using System.ComponentModel.DataAnnotations;

namespace MTBS.BookingAPI.Models
{
    public class BookingHeader
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<BookingDetails> BookingDetails { get; set; }
    }
}
