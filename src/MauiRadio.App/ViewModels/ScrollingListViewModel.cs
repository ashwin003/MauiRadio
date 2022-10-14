using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace MauiRadio.App.ViewModels
{
    public partial class ScrollingListViewModel<T> : BaseViewModel
    {
        private int pageNumber;

        private int pageSize;

        [ObservableProperty]
        private int remainingItemsThreshold;

        [ObservableProperty]
        private T selectedRecord;

        public ObservableCollection<T> Records { get; set; } = new ObservableCollection<T>();

        protected virtual T GetDefaultSelectedRecord()
        {
            throw new NotImplementedException();
        }

        protected virtual Task<IEnumerable<T>> FetchDataAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        [CommunityToolkit.Mvvm.Input.RelayCommand]
        public async Task LoadDataAsync()
        {
            if (IsLoading) return;

            pageNumber++;
            IsLoading = true;
            var records = await FetchDataAsync(pageNumber, pageSize);
            IsLoading = false;
            foreach (var record in records)
            {
                Records.Add(record);
            }
        }

        public ScrollingListViewModel(int pageSize, int remainingItemsThreshold)
        {
            pageNumber = -1;
            this.pageSize = pageSize;
            this.RemainingItemsThreshold = remainingItemsThreshold;
            this.selectedRecord = GetDefaultSelectedRecord();
        }
    }
}
