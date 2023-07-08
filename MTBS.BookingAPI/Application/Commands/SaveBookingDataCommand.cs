using MediatR;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;

namespace MTBS.BookingAPI.Application.Commands
{
    public class SaveBookingDataCommand : IRequest<int>
    {
        public BookingHeaderDto BookingHeaderDto { get; set; }
    }
}
