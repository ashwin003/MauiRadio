using MauiRadio.Core.Converters;
using Newtonsoft.Json;

namespace MauiRadio.Core.Entities
{
    public class Station
    {
        [JsonProperty("stationuuid")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("url_resolved")]
        public string Url { get; set; } = "";

        [JsonProperty("homepage")]
        public string HomePage { get; set; } = "";

        [JsonProperty("favicon")]
        public string Favicon { get; set; } = "";

        [JsonConverter(typeof(CommaSeparatedConverter))]
        [JsonProperty("tags")]
        public IEnumerable<string> Tags { get; set; } = new List<string>();

        [JsonProperty("country")]
        public string Country { get; set; } = "";

        [JsonProperty("countrycode")]
        public string CountryCode { get; set; } = "";

        [JsonProperty("state")]
        public string State { get; set; } = "";

        [JsonProperty("language")]
        public string Language { get; set; } = "";

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonProperty("codec")]
        public string Codec { get; set; } = "";
    }
}
