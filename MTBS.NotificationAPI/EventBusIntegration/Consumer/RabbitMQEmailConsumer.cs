using MTBS.EventBus;
using MTBS.NotificationAPI.EventBusIntegration.Messages;
using MTBS.NotificationAPI.Repositories;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MTBS.NotificationAPI.EventBusIntegration.Consumer
{
    public class RabbitMQEmailConsumer : BackgroundService
    {
        private readonly NotificationRepository _notificationRepository;
        private readonly RabbitMQConsumer _rabbitMQConsumer;
        private readonly IConfiguration _configuration;

        public RabbitMQEmailConsumer(NotificationRepository notificationRepository, RabbitMQConsumer rabbitMQConsumer, IConfiguration configuration)
        {
            _notificationRepository = notificationRepository;
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
            EmailLogMessage emailLog = new EmailLogMessage
            {
                EmailAddress = result.EmailAddress,
                Created = result.MessageCreated
            };

            await _notificationRepository.CreateLogEntry(emailLog);
        }
    }
}
