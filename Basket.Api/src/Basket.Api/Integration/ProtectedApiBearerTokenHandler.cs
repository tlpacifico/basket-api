using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;

namespace Basket.Api.Integration;

public class ProtectedApiBearerTokenHandler : DelegatingHandler
{
    private readonly IMemoryCache _memoryCache;

    public ProtectedApiBearerTokenHandler(
        IMemoryCache memoryCache)
    {
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
            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://azfun-impact-code-challenge-api.azurewebsites.net/api/")
            };
            //TODO: check is http code is 200
            var response = await client.PostAsJsonAsync("login",
                new RequestTokenModel() { Email = "thacio.pacifico@gmail.com" });

            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(50);
           
            var model = JsonSerializer.Deserialize<TokenModel>(await response.Content.ReadAsStringAsync());

            return model;
        });
        // set the bearer token to the outgoing request
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
        return await base.SendAsync(request, ct);
    }
}