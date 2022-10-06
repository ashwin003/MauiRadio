using MauiRadio.Core.Models;

namespace MauiRadio.Core.Services
{
    internal interface IApiService
    {
        Task<T> ProcessRequest<T>(RequestPayload requestPayload, CancellationToken cancellationToken = default);
    }
}
