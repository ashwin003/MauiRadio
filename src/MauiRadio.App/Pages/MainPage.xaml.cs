using MauiRadio.App.ViewModels;

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
    }
}
