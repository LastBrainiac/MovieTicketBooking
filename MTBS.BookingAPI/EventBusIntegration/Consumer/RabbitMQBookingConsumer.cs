using MTBS.BookingAPI.Repositories;
using MTBS.EventBus;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using MTBS.BookingAPI.EventBusIntegration.Messages;
using MTBS.BookingAPI.Models;
using AutoMapper;

namespace MTBS.BookingAPI.EventBusIntegration.Consumer
{
    public class RabbitMQBookingConsumer : BackgroundService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly RabbitMQConsumer _rabbitMQConsumer;
        private readonly IConfiguration _configuration;
        private readonly IRabbitMQMessageSender _rabbitMQMessageSender;
        private readonly IMapper _mapper;

        public RabbitMQBookingConsumer(BookingRepository bookingRepository, RabbitMQConsumer rabbitMQConsumer, IConfiguration configuration,
            IRabbitMQMessageSender rabbitMQMessageSender, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _rabbitMQConsumer = rabbitMQConsumer;
            _configuration = configuration;
            _rabbitMQMessageSender = rabbitMQMessageSender;
            _mapper = mapper;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _rabbitMQConsumer.Consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                UserFinishedBooking receivedObj = JsonSerializer.Deserialize<UserFinishedBooking>(content);
                await HandleResult(receivedObj);
                _rabbitMQConsumer.Channel.BasicAck(ea.DeliveryTag, false);
            };
            _rabbitMQConsumer.Channel.BasicConsume(_configuration["EventBus:ConsumerQueue"], false, _rabbitMQConsumer.Consumer);

            return Task.CompletedTask;
        }

        private async Task HandleResult(UserFinishedBooking result)
        {
            var bookingHeader = _mapper.Map<BookingHeader>(result);
            await _bookingRepository.SaveBookingDataAsync(bookingHeader);

            var emailLogMessage = _mapper.Map<EmailLogMessage>(bookingHeader);
            _rabbitMQMessageSender.PublishMessage(emailLogMessage, _configuration["EventBus:NotificationQueueName"]);
        }
    }
}
