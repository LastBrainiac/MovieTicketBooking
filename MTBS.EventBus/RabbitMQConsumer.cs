﻿using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MTBS.EventBus
{
    public class RabbitMQConsumer
    {
        private IConnection _connection;
        private IModel _channel;
        private EventingBasicConsumer _consumer;

        public RabbitMQConsumer(IConfiguration configuration)
        {
            var factory = new ConnectionFactory
            {
                HostName = configuration["EventBus:HostName"],
                UserName = configuration["EventBus:UserName"],
                Password = configuration["EventBus:Password"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: configuration["EventBus:ConsumerQueue"], false, false, false, arguments: null);
            _consumer = new EventingBasicConsumer(_channel);
        }

        public IModel Channel { get => _channel; }

        public EventingBasicConsumer Consumer { get => _consumer; }
    }
}
