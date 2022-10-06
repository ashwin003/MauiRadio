using MauiRadio.Core.Entities;

namespace MauiRadio.Core.Services
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> SearchStationsAsync(string countryCode, int pageNumber, int pageSize, IEnumerable<string> tags);
    }
}
