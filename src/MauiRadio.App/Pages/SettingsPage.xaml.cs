using MauiRadio.App.ViewModels;

namespace MauiRadio.App.Pages
{
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel viewModel;
        private readonly IPreferences preferencesManager;
        private readonly IServiceProvider serviceProvider;

        public SettingsPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            var viewModel = serviceProvider.GetRequiredService<SettingsViewModel>();
            this.viewModel = viewModel;
            preferencesManager = serviceProvider.GetRequiredService<IPreferences>();
            BindingContext = viewModel;
            this.serviceProvider = serviceProvider;
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            preferencesManager.Set(Constants.UserPreferencesKey, this.viewModel.SelectedCountry);
            await Navigation.PushAsync(new NavigationPage(serviceProvider.GetRequiredService<MainPage>()));
        }
    }
}
