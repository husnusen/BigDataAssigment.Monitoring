using BigDataAssigment.MonitoringApp.ForecastApiClient;
using BigDataAssigment.MonitoringApp.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BigDataAssigment.MonitoringApp
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddScoped<IForecastApiWrapper, ForecastApiWrapper>();

            services.Configure<ConsoleLifetimeOptions>(options =>  
                options.SuppressStatusMessages = true);

            services.AddLogging(config =>
            {
                config.ClearProviders();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ForecastHub>("/forecasthub");
            });
        }

    }
}
