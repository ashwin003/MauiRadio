using MauiRadio.App.ViewModels;
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

        public MainPage(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            BindingContext = serviceProvider.GetRequiredService<MainPageViewModel>();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(serviceProvider.GetRequiredService<SettingsPage>()), true);
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ShowBottomSheet(GetBottomSheetView(), true);
        }

        private View GetBottomSheetView()
        {
            var view = (View)BottomSheetTemplate.CreateContent();
            view.BindingContext = BindingContext;
            return view;
        }
    }
}
