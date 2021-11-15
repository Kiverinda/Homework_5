using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;


namespace Homework_5
{
    class ConfigurationServices
    {
        public ServiceCollection Services { get; set; }

        public ConfigurationServices()
        {
            Services = new ServiceCollection();
            ConfigureServices(Services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<AppSettings>(configuration.GetSection("App"));
            services.AddSingleton<Log>();
            //services.AddTransient<IRepositoryProduct<Clothing>, СlothingRepository>();
            //services.AddTransient<IRepositoryProduct<Automobile>, AutomobileRepository>();
            //services.AddTransient<IRepository<IProduct>, СartRepository>();
            //services.AddTransient<IControllerProduct<Clothing>, ClothingController>();
            //services.AddTransient<IControllerProduct<Automobile>, AutomobileController>();
            //services.AddTransient<IController<IProduct>, CartController>();

            // add app
            services.AddTransient<App>();
        }
    }
}
