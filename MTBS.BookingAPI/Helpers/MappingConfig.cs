using AutoMapper;
using MTBS.BookingAPI.EventBusIntegration.Messages;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Models.Dtos;

namespace MTBS.BookingAPI.Helpers
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserFinishedBooking, BookingHeader>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(q => q.BookingDetails, o => o.MapFrom(s => s.BookedMovies));

            CreateMap<BasketItem, BookingDetails>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ReservedSeats, o => o.MapFrom(s => s.BookedSeats));

            CreateMap<Seat, ReservedSeat>()
                .ForMember(d => d.SeatNumber, o => o.MapFrom(s => s.Number))
                .ForMember(d => d.RowNumber, o => o.MapFrom(s => s.Row))
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<BookingHeader, EmailLogMessage>()
                .ForMember(d => d.BookingId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.MessageCreated, o => o.Ignore());

            CreateMap<BookingHeaderDto, BookingHeader>();
            CreateMap<BookingDetailsDto, BookingDetails>();
            CreateMap<ReservedSeatDto, ReservedSeat>()
                .ForMember(q => q.SeatNumber, o => o.MapFrom(s => s.Seat))
                .ForMember(q => q.RowNumber, o => o.MapFrom(s => s.Row));
        }
    }
}
