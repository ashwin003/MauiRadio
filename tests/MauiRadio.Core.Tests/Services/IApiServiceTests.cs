using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiRadio.Core.Tests.Services
{
    public class IApiServiceTests
    {
        private readonly MockHttpMessageHandler mockHttpMessageHandler;
        private readonly RestClient restClient;
        private readonly IApiService sut;

        public IApiServiceTests()
        {
            mockHttpMessageHandler = new MockHttpMessageHandler();
            restClient = new RestClient(new RestClientOptions { BaseUrl = new Uri("http://localhost/"), ConfigureMessageHandler = (_) => mockHttpMessageHandler }).UseNewtonsoftJson();
            sut = new ApiService(restClient);
        }

        [Test]
        public async Task ShouldDeserializeDataAsExpected()
        {
            // Arrange
            var requestPayload = new RequestPayload
            {
                ResourceUri = "stations/search"
            };
            var testData = File.ReadAllText("TestData/Stations.json");
            mockHttpMessageHandler.When("http://localhost/stations/search")
                                  .Respond("application/json", testData);

            // Act
            await sut.ProcessRequest<List<Station>>(requestPayload);
        }
    }
}
