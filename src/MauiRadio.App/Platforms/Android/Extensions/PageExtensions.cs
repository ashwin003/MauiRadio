using Google.Android.Material.BottomSheet;
using Microsoft.Maui.Platform;

namespace MauiRadio.App.Platforms.Android.Extensions
{
    public static class PageExtensions
    {
        public static void ShowBottomSheet(this Page page, IView bottomSheetContent, bool dimDismiss)
        {
            try
            {
                var bottomSheetDialog = new BottomSheetDialog(Platform.CurrentActivity?.Window?.DecorView.FindViewById(16908290)?.Context);
                bottomSheetDialog.SetContentView(bottomSheetContent.ToPlatform(page.Handler?.MauiContext ?? throw new Exception("MauiContext is null")));
                bottomSheetDialog.Show();
            }
            catch { }
        }
    }
}
