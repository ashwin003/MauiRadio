using MauiRadio.App.ViewModels;
using MauiRadio.App.Services;
#if WINDOWS
using MauiRadio.App.Platforms.Windows.Extensions;
#endif
#if ANDROID
using MauiRadio.App.Platforms.Android.Extensions;
#endif
#if IOS
using MauiRadio.App.Platforms.iOS.Extensions;
#endif
#if MACCATALYST
using MauiRadio.App.Platforms.MacCatalyst.Extensions;
#endif

namespace MauiRadio.App.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider serviceProvider;
        private readonly MainPageViewModel viewModel;
        private readonly IMusicPlayer musicPlayer;

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            viewModel = serviceProvider.GetRequiredService<MainPageViewModel>();
            BindingContext = viewModel;
            musicPlayer = serviceProvider.GetRequiredService<IMusicPlayer>();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(serviceProvider.GetRequiredService<SettingsPage>()), true);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(viewModel.SelectedRecord.Url))
            {
                this.ShowBottomSheet(GetBottomSheetView(), true);
                this.musicPlayer.Stop();
                var playing = this.musicPlayer.Play(viewModel.SelectedRecord);
                Console.WriteLine(playing);
            }
        }

        private View GetBottomSheetView()
        {
            var view = (View)BottomSheetTemplate.CreateContent();
            view.BindingContext = BindingContext;
            return view;
        }
    }
}
