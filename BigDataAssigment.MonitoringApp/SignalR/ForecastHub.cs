using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BigDataAssigment.MonitoringApp.SignalR
{
    public class ForecastHub : Hub
    {
        [HubMethodName("SendMessage")]
        public async Task SendMessage(Forecast forecast)
        {
            Console.WriteLine(String.Format("{0,-13} | {1,-20} | {2,-24} | {3,-23}", forecast.Location.LocationName, forecast.CurrentTemperature, forecast.MaxTemperatureWeekly, forecast.MinTemperatureWeekly));
        }

    }
}
