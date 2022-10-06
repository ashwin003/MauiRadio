using MauiRadio.Core.Extensions;
using MauiRadio.Core.Services;
using MauiRadio.Core.Services.Implementations;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRadioBrowser(this IServiceCollection services)
        {
            return services
                .AddSingleton(factory =>
                {
                    var availableServers = new List<string>
                    {
                        "https://at1.api.radio-browser.info/json/",
                        "https://de1.api.radio-browser.info/json/",
                        "https://nl1.api.radio-browser.info/json/"
                    };

                    var selectedServer = availableServers.PickRandom();
                    return new RestClient(selectedServer).UseNewtonsoftJson();
                })
                .AddSingleton<IApiService, ApiService>()
                .AddTransient<IStationService, StationService>()
                .AddTransient<ICountryService, CountryService>();
        }
    }
}