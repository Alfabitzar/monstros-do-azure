using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace ServiceBus.HandsOn.Queue.Consumer
{
    public class QueueConsumer
    {
        [FunctionName("consumer")]
        public void Run([ServiceBusTrigger("ping", Connection = "ServiceBusConnectionString")] string myQueueItem, ILogger log)
        {
            log.LogWarning($"New Message: {myQueueItem} / At {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }
    }
}
