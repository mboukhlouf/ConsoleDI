using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI
{
    class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IConfiguration Configuration { get; private set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            var scope = ServiceProvider.CreateScope();
            var app = scope.ServiceProvider.GetRequiredService<Application>();
            app.Run(args);
            scope.Dispose();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<Application>();
        }
    }
}
