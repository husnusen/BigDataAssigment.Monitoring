using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BigDataAssigment.MonitoringApp.Models;

namespace BigDataAssigment.MonitoringApp.ForecastApiClient
{
    public interface IForecastApiWrapper
    {
        Task<IList<Forecast>> GetForecasts();
    }
}
