using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using __Namespace__.__Service__.Core;
using __Namespace__.__Service__.Core.MessageHandlers.Interfaces;

namespace __Namespace__.__Service__.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false);

            IConfiguration configuration = configurationBuilder.Build();

            var serviceProvider = new ServiceCollection();
            serviceProvider.AddSingleton<IConfiguration>(configuration);

            new __Service__Builder(configuration).ConfigureServices(serviceProvider);

            var services = serviceProvider.BuildServiceProvider();

            Console.WriteLine("__Service__ Consumer started");

            var consumer = services.GetService<I__Service__Consumer>();
            consumer.CreateConsumer();

            // Handle Cancel Keypress 
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true; // prevent the process from terminating.
                consumer.Polling = false;
            };

            Console.WriteLine("Ctrl-C to exit.");          
        }
    }    
}
