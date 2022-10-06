using MauiRadio.App.Services;
using MauiRadio.App.ViewModels;

namespace MauiRadio.App.Pages
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel viewModel;
        private readonly IPreferenceManager preferencesManager;
        private readonly MainPage mainPage;

        public SettingsPage(SettingsViewModel viewModel, IPreferenceManager preferencesManager, MainPage mainPage)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.preferencesManager = preferencesManager;
            this.mainPage = mainPage;
            this.BindingContext = viewModel;
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            preferencesManager.SavePreferences(Constants.UserPreferencesKey, this.viewModel.SelectedCountry);
            Navigation.PushAsync(new NavigationPage(mainPage));
        }
    }
}
