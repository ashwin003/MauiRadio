using MauiRadio.App.Pages;
using MauiRadio.App.Services;

namespace MauiRadio.App
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider, IPreferenceManager preferencesManager)
        {
            InitializeComponent();

            var arePreferencesSaved = preferencesManager.ContainsKey(Constants.UserPreferencesKey);
            MainPage = new NavigationPage(arePreferencesSaved ? serviceProvider.GetRequiredService<MainPage>() : serviceProvider.GetRequiredService<SettingsPage>());
        }
    }
}
