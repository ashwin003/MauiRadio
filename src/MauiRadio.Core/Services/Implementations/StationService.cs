using MauiRadio.Core.Entities;
using MauiRadio.Core.Models;
using RestSharp;

namespace MauiRadio.Core.Services.Implementations
{
    internal class StationService : IStationService
    {
        private readonly IApiService apiService;

        public StationService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<IEnumerable<Station>> SearchStationsAsync(string countryCode, int pageNumber, int pageSize, IEnumerable<string> tags)
        {
            var parameters = new List<Parameter>
            {
                Parameter.CreateParameter("countrycode", countryCode, ParameterType.QueryString),
                Parameter.CreateParameter("offset", (pageNumber - 1) * pageSize, ParameterType.QueryString),
                Parameter.CreateParameter("limit", pageSize, ParameterType.QueryString),
                Parameter.CreateParameter("hidebroken", true, ParameterType.QueryString),
                Parameter.CreateParameter("order", "clickcount", ParameterType.QueryString),
                Parameter.CreateParameter("reverse", true, ParameterType.QueryString),
            };
            if(tags.Any())
            {
                parameters.Add(Parameter.CreateParameter("tagList", string.Join(",", tags), ParameterType.QueryString));
            }

            var requestPayload = new RequestPayload
            {
                ResourceUri = "stations/search",
                Parameters = parameters,
            };
            return await apiService.ProcessRequest<IEnumerable<Station>>(requestPayload);
        }
    }
}
