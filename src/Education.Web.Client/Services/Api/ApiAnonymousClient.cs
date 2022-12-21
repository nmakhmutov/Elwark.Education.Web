namespace Education.Web.Client.Services.Api;

internal sealed class ApiAnonymousClient
{
    private readonly HttpClient _httpClient;

    public ApiAnonymousClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<HttpResponseMessage> GetAsync(string uri, CancellationToken ct) =>
        _httpClient.GetAsync(uri, ct);
}
