namespace MauiRadio.App.Services
{
    public interface IPreferenceManager
    {
        bool SavePreferences<T>(string key, T value);

        T? FetchPreferences<T>(string key);

        bool ContainsKey(string key);
    }
}
