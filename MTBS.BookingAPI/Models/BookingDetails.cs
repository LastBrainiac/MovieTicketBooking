using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTBS.BookingAPI.Models
{
    public class BookingDetails
    {
        [Key]
        public int Id { get; set; }
        public string MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int TicketQuantity { get; set; }
        public int TicketPrice { get; set; }
        public DateTime ScreeningDate { get; set; }        
        public int BookingHeaderId { get; set; }
        [ForeignKey(nameof(BookingHeaderId))]
        public virtual BookingHeader BookingHeader { get; set; }
        public List<ReservedSeat> ReservedSeats { get; set; }
    }
}
