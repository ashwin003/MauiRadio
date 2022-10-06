using Newtonsoft.Json;

namespace MauiRadio.App.Services
{
    internal class PreferenceManager : IPreferenceManager
    {
        public bool ContainsKey(string key)
        {
            var value = Preferences.Get(key, null);
            return value is not null;
        }

        public T? FetchPreferences<T>(string key)
        {
            var value = Preferences.Get(key, null);
            return value is null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        public bool SavePreferences<T>(string key, T value)
        {
            var stringValue = JsonConvert.SerializeObject(value);
            Preferences.Set(key, stringValue);
            return true;
        }
    }
}
