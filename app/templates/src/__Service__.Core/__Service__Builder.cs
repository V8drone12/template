using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using __Namespace__.__Service__.Core.Domain.Repositories;
using __Namespace__.__Service__.Core.Domain.Repositories.Interfaces;
using __Namespace__.__Service__.Core.MessageHandlers;
using __Namespace__.__Service__.Core.MessageHandlers.Interfaces;
using __Namespace__.__Service__.Data;
using __Namespace__.__Service__.Data.Interfaces;
using __Service__.Data;

namespace __Namespace__.__Service__.Core
{
    public class __Service__Builder
    {
        private readonly IConfiguration _configuration;

        public __Service__Builder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddTransient<I__Service__Repository, __Service__Repository>();
            services.AddTransient<I__Service__DbContext, __Service__DbContext>();
            services.AddSingleton<I__Service__Consumer, __Service__Consumer>();
            services.AddSingleton<I__Service__Producer, __Service__Producer>();

            new DbContextFactory().BuildDbContext(services, _configuration);

        }
    }
}
