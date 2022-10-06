using RestSharp;

namespace MauiRadio.Core.Models
{
    internal class RequestPayload
    {
        public string ResourceUri { get; init; } = "";

        public Method Method { get; init; } = Method.Get;

        public IEnumerable<Parameter> Parameters { get; init; } = new List<Parameter>();
    }
}
