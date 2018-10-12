using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Configuration;
using __Namespace__.__Service__.Core.MessageHandlers.Interfaces;

namespace __Namespace__.__Service__.Core.MessageHandlers
{
    public class __Service__Consumer : I__Service__Consumer
    {
        private readonly Dictionary<string, object> _consumerConfig;
        private readonly string _kafkaTopic;

        public bool Polling { get; set; }

        public __Service__Consumer(IConfiguration config){
            _kafkaTopic = config.GetValue<string>("Kafka:topic");
            _consumerConfig = new Dictionary<string, object>
            {
                { "group.id", config.GetValue<string>("ServiceName") },
                { "bootstrap.servers", config.GetValue<string>("Kafka:endpoint") },
            };
        }

        public void CreateConsumer()
        {
            using (var consumer = new Consumer<Null, string>(_consumerConfig, null, new StringDeserializer(Encoding.UTF8)))
            {
                Polling = true;

                // Subscribe to the OnMessage event
                consumer.OnMessage += (obj, msg) =>
                {
                    Console.WriteLine($"Received: {msg.Value}");
                };

                // Subscribe to the Kafka topic
                consumer.Subscribe(new List<string>() { _kafkaTopic });
                
                // Poll for messages
                while (Polling)
                {
                    consumer.Poll();
                }
            }
        }

        public void Poll()
        {
            throw new NotImplementedException();
        }
    }
}
