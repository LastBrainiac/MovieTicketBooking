namespace MTBS.EventBus
{
    public interface IRabbitMQMessageSender
    {
        void PublishMessage<T>(T message, string queueName) where T : BaseMessage;
    }
}
