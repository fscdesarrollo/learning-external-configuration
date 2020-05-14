using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.ConfigServer;
using System;

namespace Learning.ExternalConfiguration.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        var hostingEnviroment = hostingContext.HostingEnvironment;
                        var azureConnectionString = Environment.GetEnvironmentVariable("AZURE_CONNECTION_STRING");
                        config.AddAzureAppConfiguration(azureConnectionString); //Get connection strin to connect Azure App Configuration

                        if (hostingEnviroment.EnvironmentName.Equals("ExternalConfig"))
                        {
                            config.AddConfigServer();
                        }
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}