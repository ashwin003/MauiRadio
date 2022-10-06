using MauiRadio.Core.Extensions;
using MauiRadio.Core.Models;
using RestSharp;

namespace MauiRadio.Core.Services.Implementations
{
    internal class ApiService : IApiService
    {
        private readonly RestClient restClient;

        public ApiService(RestClient restClient)
        {
            this.restClient = restClient;
        }

        public async Task<T> ProcessRequest<T>(RequestPayload requestPayload, CancellationToken cancellationToken = default)
        {
            var restRequest = requestPayload.ToRestRequest();
            var restResponse = await restClient.ExecuteAsync<T>(restRequest, cancellationToken);
            if(restResponse.IsSuccessful && restResponse.Data is not null)
            {
                return restResponse.Data!;
            }
            throw restResponse.ErrorException ?? new Exception("Something went wrong while executing the request " + requestPayload.ResourceUri);
        }
    }
}
