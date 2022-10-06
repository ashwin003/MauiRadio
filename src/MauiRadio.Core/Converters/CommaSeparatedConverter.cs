using Newtonsoft.Json;

namespace MauiRadio.Core.Converters
{
    public class CommaSeparatedConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if(reader.Value is null) return Enumerable.Empty<string>();
            return reader.Value.ToString()!.Split(",");
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
