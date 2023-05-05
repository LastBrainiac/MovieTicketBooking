using AutoMapper;
using MTBS.EventBus;
using MTBS.NotificationAPI.EventBusIntegration.Messages;
using MTBS.NotificationAPI.Models;
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
        private readonly IMapper _mapper;

        public RabbitMQEmailConsumer(NotificationRepository notificationRepository, RabbitMQConsumer rabbitMQConsumer,
            IConfiguration configuration, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _rabbitMQConsumer = rabbitMQConsumer;
            _configuration = configuration;
            _mapper = mapper;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            _rabbitMQConsumer.Consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                EmailLogMessage receivedObj = JsonSerializer.Deserialize<EmailLogMessage>(content);
                await HandleResult(receivedObj);
                _rabbitMQConsumer.Channel.BasicAck(ea.DeliveryTag, false);
            };
            _rabbitMQConsumer.Channel.BasicConsume(_configuration["EventBus:ConsumerQueue"], false, _rabbitMQConsumer.Consumer);

            return Task.CompletedTask;
        }

        private async Task HandleResult(EmailLogMessage result)
        {
            var emailLog = _mapper.Map<EmailLog>(result);
            await _notificationRepository.CreateLogEntry(emailLog);
        }
    }
}
