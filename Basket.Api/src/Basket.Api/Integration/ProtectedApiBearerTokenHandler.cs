using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;

namespace Basket.Api.Integration;

public class ProtectedApiBearerTokenHandler : DelegatingHandler
{
    private readonly ICatalogIntegration _client;
    private readonly IMemoryCache _memoryCache;

    public ProtectedApiBearerTokenHandler(
        ICatalogIntegration client,
        IMemoryCache memoryCache)
    {
        _client = client;
        _memoryCache = memoryCache;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken ct)
    {
        var key = $"authToken";
        var accessToken = await _memoryCache.GetOrCreateAsync(key, async entry =>
        {
            // request the access token
            var accessToken = await _client.GetTokenAsync(ct);

            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(50);

            return accessToken;
        });
        // set the bearer token to the outgoing request
        request.Headers.Authorization = new AuthenticationHeaderValue("bearer", accessToken.Token);
        return await base.SendAsync(request, ct);
    }
}