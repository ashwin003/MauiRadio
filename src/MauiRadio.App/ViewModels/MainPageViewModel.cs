using MauiRadio.App.Services;
using MauiRadio.Core.Entities;
using MauiRadio.Core.Services;

namespace MauiRadio.App.ViewModels
{
    public partial class MainPageViewModel : ScrollingListViewModel<Station>
    {
        private readonly IStationService stationService;
        private readonly Country preference;

        public MainPageViewModel(IPreferences preferenceManager, IStationService stationService) : base(pageSize: 15, remainingItemsThreshold: 3)
        {
            preference = preferenceManager.Get(Constants.UserPreferencesKey, new Country())!;
            Title = preference.Name;
            this.stationService = stationService;
        }

        protected override Station GetDefaultSelectedRecord()
        {
            return new Station();
        }

        protected override async Task<IEnumerable<Station>> FetchDataAsync(int pageNumber, int pageSize)
        {
            return await Task.Run(async () => await stationService.SearchStationsAsync(preference.Code, pageNumber, pageSize, Enumerable.Empty<string>()));
        }
    }
}
