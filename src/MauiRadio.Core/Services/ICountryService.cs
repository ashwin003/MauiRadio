using MauiRadio.Core.Entities;

namespace MauiRadio.Core.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> FetchCountriesAsync();
    }
}
