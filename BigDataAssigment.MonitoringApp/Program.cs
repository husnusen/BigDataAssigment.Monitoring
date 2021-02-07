using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;

namespace BigDataAssigment.MonitoringApp
{
    class Program
    {
       static  void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();

            IForecastApiWrapper forecastApiWrapper = new ForecastApiWrapper();
            var forecastList =  forecastApiWrapper.GetForecasts().ConfigureAwait(false).GetAwaiter().GetResult();
           

            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Location Name | Current Temperature  |   Max Weekly Temperature | Min Weekly Temperature");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            
           foreach (var forecast in forecastList) {
                Console.WriteLine(String.Format("{0,-13} | {1,-20} | {2,-24} | {3,-23}", forecast.Location.LocationName, forecast.CurrentTemperature,forecast.MaxTemperatureWeekly, forecast.MinTemperatureWeekly));

             }
            
            host.Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls("https://localhost:5002/")
            .SuppressStatusMessages(true)
            .UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "True");

    }
}
