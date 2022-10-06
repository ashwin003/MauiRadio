using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiRadio.App.ViewModels
{
    [INotifyPropertyChanged]
    public partial class BaseViewModel
    {
        [ObservableProperty]
        private string title = "";

        [ObservableProperty]
        private bool isLoading;
    }
}
