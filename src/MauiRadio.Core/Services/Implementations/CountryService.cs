using MauiRadio.Core.Entities;
using MauiRadio.Core.Models;

namespace MauiRadio.Core.Services.Implementations
{
    internal class CountryService : ICountryService
    {
        private readonly IApiService apiService;

        public CountryService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<IEnumerable<Country>> FetchCountriesAsync()
        {
            var requestPayload = new RequestPayload
            {
                ResourceUri = "countries"
            };
            return await apiService.ProcessRequest<IEnumerable<Country>>(requestPayload);
        }
    }
}
