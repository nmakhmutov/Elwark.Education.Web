using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Store.Catalog;

internal sealed class CatalogClient : GatewayClient
{
    private readonly HttpClient _client;

    public CatalogClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<Subscription[]>> GetSubscriptions() =>
        ExecuteAsync<Subscription[]>(ct => _client.GetAsync("store/catalog/subscriptions", ct));

    public Task<ApiResponse<Subscription[]>> GetSubscriptions(SubjectType subject) =>
        ExecuteAsync<Subscription[]>(ct => _client.GetAsync($"store/catalog/subscriptions/{subject}", ct));
}
