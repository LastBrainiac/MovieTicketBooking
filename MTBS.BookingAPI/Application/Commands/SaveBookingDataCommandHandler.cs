using AutoMapper;
using MediatR;
using MTBS.BookingAPI.Models;
using MTBS.BookingAPI.Repositories;

namespace MTBS.BookingAPI.Application.Commands
{
    public class SaveBookingDataCommandHandler : IRequestHandler<SaveBookingDataCommand, int>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public SaveBookingDataCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(SaveBookingDataCommand request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.SaveBookingDataAsync(_mapper.Map<BookingHeader>(request.BookingHeaderDto));
        }
    }
}
