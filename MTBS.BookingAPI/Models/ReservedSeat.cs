using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTBS.BookingAPI.Models
{
    public class ReservedSeat
    {
        [Key]
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public int BookingDetailsId { get; set; }
        [ForeignKey(nameof(BookingDetailsId))]
        public virtual BookingDetails BookingDetails { get; set; }
    }
}
