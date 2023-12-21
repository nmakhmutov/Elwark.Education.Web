namespace Education.Client.Clients;

internal sealed class ApiAuthenticatedClient
{
    private readonly HttpClient _httpClient;

    public ApiAuthenticatedClient(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<HttpResponseMessage> GetAsync(string uri, CancellationToken ct) =>
        _httpClient.GetAsync(uri, ct);

    public Task<HttpResponseMessage> PostAsync(string? uri, HttpContent? content, CancellationToken ct) =>
        _httpClient.PostAsync(uri, content, ct);

    public Task<HttpResponseMessage> PutAsync(string? uri, HttpContent? content, CancellationToken ct) =>
        _httpClient.PutAsync(uri, content, ct);

    public Task<HttpResponseMessage> DeleteAsync(string uri, CancellationToken ct) =>
        _httpClient.DeleteAsync(uri, ct);
}
