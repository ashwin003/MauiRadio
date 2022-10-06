using Newtonsoft.Json;

namespace MauiRadio.Core.Entities
{
    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("iso_3166_1")]
        public string Code { get; set; } = "";

        public string Flag { get => string.Concat(Code.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5))); }
    }
}
