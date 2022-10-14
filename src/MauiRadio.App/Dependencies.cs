using LibVLCSharp.Shared;
using MauiRadio.App.Pages;
using MauiRadio.App.Services;
using MauiRadio.App.ViewModels;

namespace Microsoft.Extensions.DependencyInjection
{
    internal static class Dependencies
    {
        internal static IServiceCollection AddViewModel(this IServiceCollection services)
        {
            return services
                .AddTransient<MainPageViewModel>()
                .AddTransient<SettingsViewModel>();
        }

        internal static IServiceCollection AddPages(this IServiceCollection services)
        {
            return services
                .AddTransient<MainPage>()
                .AddTransient<SettingsPage>();
        }

        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IPreferenceManager, PreferenceManager>()
                .AddSingleton<LibVLC>((s) => new LibVLC())
                .AddSingleton<MediaPlayer>()
                .AddTransient<IMusicPlayer, MusicPlayer>();
        }
    }
}
