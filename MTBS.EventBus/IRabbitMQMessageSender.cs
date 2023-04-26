using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.EventBus
{
    public interface IRabbitMQMessageSender
    {
        void PublishMessage<T>(T message, string queueName) where T : BaseMessage;
    }
}
