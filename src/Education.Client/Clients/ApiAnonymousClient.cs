namespace Education.Client.Clients;

internal sealed class ApiAnonymousClient
{
    private readonly HttpClient _httpClient;

    public ApiAnonymousClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<HttpResponseMessage> GetAsync(string uri, CancellationToken ct) =>
        _httpClient.GetAsync(uri, ct);

    public Task<HttpResponseMessage> PostAsync(string uri, HttpContent? content, CancellationToken ct) =>
        _httpClient.PostAsync(uri, content, ct);
}
