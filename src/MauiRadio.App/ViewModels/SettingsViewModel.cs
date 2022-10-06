using CommunityToolkit.Mvvm.ComponentModel;
using MauiRadio.App.Models;
using MauiRadio.Core.Entities;
using MauiRadio.Core.Services;

namespace MauiRadio.App.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel(ICountryService countryService)
        {
            Title = "Preferences";
            IsLoading = true;
            Task.Run(async () =>
            {
                var countries = await countryService.FetchCountriesAsync();
                foreach (var country in countries.OrderBy(c => c.Name).GroupBy(c => c.Name[0]))
                {
                    Countries.Add(new Grouped<Country>(country.Key.ToString(), country.ToList()));
                    OnPropertyChanged(nameof(Countries));
                }
                IsLoading = false;
            });
        }

        public IList<Grouped<Country>> Countries { get; private set; } = new List<Grouped<Country>>();

        [ObservableProperty]
        private Country? selectedCountry;
    }
}
