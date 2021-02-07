using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace BigDataAssigment.MonitoringApp
{
    public class ForecastApiWrapper :IForecastApiWrapper
    {
        private  HttpClient _httpClient;
        private  HttpClient ForecastHttpClient
        {
            get
            {
                if (_httpClient != null) return _httpClient;

                _httpClient = new HttpClient
                { BaseAddress = new Uri("https://localhost:5001/api/Forecast") };
                return _httpClient;
            }
        }


        public async Task<IList<Forecast>> GetForecasts() {

            var forecastHttpClient = new FlurlClient(ForecastHttpClient);

             return await forecastHttpClient
                .Request()
                .GetJsonAsync<IList<Forecast>>()
                .ConfigureAwait(false);
        }

    }
}
