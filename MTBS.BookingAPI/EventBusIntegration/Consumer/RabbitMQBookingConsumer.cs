using MTBS.BookingAPI.Repositories;
using MTBS.EventBus;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using MTBS.BookingAPI.EventBusIntegration.Messages;
using MTBS.BookingAPI.Models;

namespace MTBS.BookingAPI.EventBusIntegration.Consumer
{
    public class RabbitMQBookingConsumer : BackgroundService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly RabbitMQConsumer _rabbitMQConsumer;
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;

        public RabbitMQBookingConsumer(BookingRepository bookingRepository, RabbitMQConsumer rabbitMQConsumer, IConfiguration configuration, IRabbitMQMessageSender rabbitMQMessageSender)
        {
            _bookingRepository = bookingRepository;
            _rabbitMQConsumer = rabbitMQConsumer;
            _configuration = configuration;
            _rabbitMQMessageSender = rabbitMQMessageSender;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _rabbitMQConsumer.Consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                UserFinishedBooking receivedObj = JsonSerializer.Deserialize<UserFinishedBooking>(content);
                HandleResult(receivedObj).GetAwaiter().GetResult();
                _rabbitMQConsumer.Channel.BasicAck(ea.DeliveryTag, false);
            };
            _rabbitMQConsumer.Channel.BasicConsume(_configuration["EventBus:ConsumerQueue"], false, _rabbitMQConsumer.Consumer);

            return Task.CompletedTask;
        }

        private async Task HandleResult(UserFinishedBooking result)
        {
            BookingHeader bookingHeader = new BookingHeader
            {
                FullName = result.FullName,
                EmailAddress = result.EmailAddress,
                PhoneNumber = result.PhoneNumber,
            };

            var bookingDetailsList = new List<BookingDetails>();
            foreach (var movie in result.BookedMovies)
            {
                BookingDetails bookingDetails = new BookingDetails
                {
                    MovieId = movie.MovieId,
                    MovieTitle = movie.MovieTitle,
                    ScreeningDate = movie.ScreeningDate,
                    TicketQuantity = movie.TicketQuantity
                };

                var reservedSeatList = new List<ReservedSeat>();
                foreach (var seat in movie.BookedSeats)
                {                    
                    ReservedSeat reservedSeat = new ReservedSeat
                    {
                        RowNumber = seat.Row,
                        SeatNumber = seat.Number
                    };
                    reservedSeatList.Add(reservedSeat);
                }
                bookingDetails.ReservedSeats = reservedSeatList;
                bookingDetailsList.Add(bookingDetails);
            }
            bookingHeader.BookingDetails = bookingDetailsList;

            await _bookingRepository.SaveBookingDataAsync(bookingHeader);

            var emailLogMessage = new EmailLogMessage
            {
                BookingId = bookingHeader.Id,
                EmailAddress = bookingHeader.EmailAddress
            };

            _rabbitMQMessageSender.PublishMessage(emailLogMessage, _configuration["EventBus:NotificationQueueName"]);
        }
    }
}
