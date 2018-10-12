using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Configuration;
using __Namespace__.__Service__.Core.MessageHandlers.Interfaces;

namespace __Namespace__.__Service__.Core.MessageHandlers
{
    public class __Service__Producer : I__Service__Producer
    {
        private readonly string _kafkaTopic;
        private readonly Dictionary<string, object> _producerConfig;

        public __Service__Producer(IConfiguration config)
        {
            _kafkaTopic = config.GetValue<string>("Kafka:topic");
            _producerConfig = new Dictionary<string, object>
            {
                { "bootstrap.servers", config.GetValue<string>("Kafka:endpoint") },
            };
        }

        public void Produce(string message)
        {
            // Create the producer
            using (var producer = new Producer<Null, string>(_producerConfig, null, new StringSerializer(Encoding.UTF8)))
            {                
                var result = producer.ProduceAsync(_kafkaTopic, null, message).GetAwaiter().GetResult();
                Console.WriteLine($"Event {result.Key} sent on Partition: {result.Partition} with Offset: {result.Offset}");             
            }
        }
    }
}
