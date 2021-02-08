using System;
using System.Threading.Tasks;
using BigDataAssigment.MonitoringApp.ForecastApiClient;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BigDataAssigment.MonitoringApp
{
    class Program
    { 
       static  void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();
            PrintForecastData(host.Services).Wait();
            
            host.Run();
        }

        private static async Task PrintForecastData(IServiceProvider services) {

            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;


            IForecastApiWrapper forecastApiWrapper = provider.GetRequiredService<IForecastApiWrapper>();
            var forecastList = await forecastApiWrapper.GetForecasts().ConfigureAwait(false);


            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Location Name | Current Temperature  |   Max Weekly Temperature | Min Weekly Temperature");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            foreach (var forecast in forecastList)
            {
                Console.WriteLine(String.Format("{0,-13} | {1,-20} | {2,-24} | {3,-23}", forecast.Location.LocationName, forecast.CurrentTemperature, forecast.MaxTemperatureWeekly, forecast.MinTemperatureWeekly));

            }

        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls("https://localhost:5002/")
            .SuppressStatusMessages(true)
            .UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "True");

    }
}
