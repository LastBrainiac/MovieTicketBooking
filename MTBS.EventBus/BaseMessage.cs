namespace MTBS.EventBus
{
    public class BaseMessage
    {
        public BaseMessage()
        {
            Id = Guid.NewGuid();
            MessageCreated = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime MessageCreated { get; set; }
    }
}