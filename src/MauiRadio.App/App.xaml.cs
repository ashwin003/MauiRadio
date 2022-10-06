using MauiRadio.App.Pages;
using MauiRadio.App.Services;

namespace MauiRadio.App
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider, IPreferenceManager preferencesManager)
        {
            InitializeComponent();

            MainPage = new NavigationPage(preferencesManager.ContainsKey(Constants.UserPreferencesKey) ? serviceProvider.GetRequiredService<MainPage>() : serviceProvider.GetRequiredService<SettingsPage>());
        }
    }
}
