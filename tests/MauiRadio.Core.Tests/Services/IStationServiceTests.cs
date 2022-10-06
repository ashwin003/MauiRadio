namespace MauiRadio.Core.Tests.Services
{
    public class IStationServiceTests
    {
        private readonly Mock<IApiService> mockApiService;
        private readonly IStationService sut;

        public IStationServiceTests()
        {
            mockApiService = new Mock<IApiService>();
            sut = new StationService(mockApiService.Object);
        }

        [Test]
        public async Task ShouldReturnTheExpectedResult()
        {
            // Arrange
            var numberOfStations = 10;
            var countryCode = "AU";
            int pageNumber = 2, pageSize = 15;
            var station = new Station();
            var requestPayload = It.Is<RequestPayload>(p => p.ResourceUri == "stations/search");
            mockApiService.Setup(m => m.ProcessRequest<IEnumerable<Station>>(requestPayload, default))
                          .ReturnsAsync(Enumerable.Repeat(station, numberOfStations));

            // Act
            var stations = await sut.SearchStationsAsync(countryCode, pageNumber, pageSize, Enumerable.Empty<string>());

            // Assert
            mockApiService.Verify(m => m.ProcessRequest<IEnumerable<Station>>(requestPayload, default), Times.Once);
        }
    }
}
