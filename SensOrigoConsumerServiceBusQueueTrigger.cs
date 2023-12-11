 using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SensOrigoConsumer
{
    public class SensOrigoConsumerServiceBusQueueTrigger
    {
        private readonly ILogger<SensOrigoConsumerServiceBusQueueTrigger> _logger;

        public SensOrigoConsumerServiceBusQueueTrigger(ILogger<SensOrigoConsumerServiceBusQueueTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(SensOrigoConsumerServiceBusQueueTrigger))]
        public void Run([ServiceBusTrigger("sensorigoqueue", Connection = "SensOrigo_SERVICEBUS")] ServiceBusReceivedMessage message)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);
        }
    }
}
