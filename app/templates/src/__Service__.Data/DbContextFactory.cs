using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace __Namespace__.__Service__.Data
{
    public class DbContextFactory
    {
        public void BuildDbContext(IServiceCollection services, IConfiguration config)
        {
            switch (config.GetValue<string>("Db:type"))
            {
                case "sql":
                    services.AddDbContext<__Service__DbContext>
                        (options => options.UseSqlServer(
                            config.GetValue<string>("Db:connectionString"),
                            b => b.MigrationsAssembly("__Service__.Data")));
                    break;
                default:
                    throw new ArgumentNullException("Config file is missing Database section");
            }
        }
    }
}
