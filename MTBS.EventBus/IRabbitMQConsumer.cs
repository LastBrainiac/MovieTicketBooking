using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MTBS.EventBus
{
    public interface IRabbitMQConsumer
    {
        public IModel Channel { get; }
        public EventingBasicConsumer Consumer { get; } 
    }
}
