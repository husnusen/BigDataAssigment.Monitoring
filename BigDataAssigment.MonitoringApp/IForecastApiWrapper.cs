using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigDataAssigment.MonitoringApp
{
    public interface IForecastApiWrapper
    {
        Task<IList<Forecast>> GetForecasts();
    }
}
