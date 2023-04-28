using MTBS.BookingAPI.Repositories;
using MTBS.EventBus;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using MTBS.BookingAPI.EventBusIntegration.Messages;

namespace MTBS.BookingAPI.EventBusIntegration.Consumer
{
    public class RabbitMQBookingConsumer : BackgroundService
    {
        private readonly BookingRepository _bookingRepository;
        private readonly RabbitMQConsumer _rabbitMQConsumer;
        private readonly IConfiguration _configuration;

        public RabbitMQBookingConsumer(BookingRepository bookingRepository, RabbitMQConsumer rabbitMQConsumer, IConfiguration configuration)
        {
            _bookingRepository = bookingRepository;
            _rabbitMQConsumer = rabbitMQConsumer;
            _configuration = configuration;
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

        }
    }
}
