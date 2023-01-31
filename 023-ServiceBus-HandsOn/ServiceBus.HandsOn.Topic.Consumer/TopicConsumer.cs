using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace ServiceBus.HandsOn.Topic.Consumer
{
    public class TopicConsumer
    {
        private readonly ILogger<TopicConsumer> _logger;

        public TopicConsumer(ILogger<TopicConsumer> log)
        {
            _logger = log;
        }

        [FunctionName("news-all")]
        public void RunAll([ServiceBusTrigger("news", "All", Connection = "ServiceBusConnectionString")]string mySbMsg)
        {
            _logger.LogWarning($"All: {mySbMsg} / At {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

        [FunctionName("news-sports")]
        public void RunSports([ServiceBusTrigger("news", "Sports", Connection = "ServiceBusConnectionString")] string mySbMsg)
        {
            _logger.LogWarning($"Sports: {mySbMsg} / At {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

        [FunctionName("news-police")]
        public void RunPolice([ServiceBusTrigger("news", "Police", Connection = "ServiceBusConnectionString")] string mySbMsg)
        {
            _logger.LogWarning($"Police: {mySbMsg} / At {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

        [FunctionName("news-technology")]
        public void RunTechnology([ServiceBusTrigger("news", "Technology", Connection = "ServiceBusConnectionString")] string mySbMsg)
        {
            _logger.LogWarning($"Technology: {mySbMsg} / At {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }

    }
}
