using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Store.Basket;

internal sealed class BasketClient : GatewayClient
{
    private readonly HttpClient _client;

    public BasketClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<Basket>> GetAsync() =>
        ExecuteAsync<Basket>(ct => _client.GetAsync("store/basket", ct));

    public Task<ApiResponse<Unit>> AddItemAsync(string productId) =>
        ExecuteAsync<Unit>(ct => _client.PutAsync($"store/basket/items/{productId}", EmptyContent, ct));

    public Task<ApiResponse<Unit>> RemoveItemAsync(string productId) =>
        ExecuteAsync<Unit>(ct => _client.DeleteAsync($"store/basket/items/{productId}", ct));

    public Task<ApiResponse<Unit>> AddPromoCodeAsync(string code) =>
        ExecuteAsync<Unit>(ct => _client.PutAsync($"store/basket/promo-codes/{code}", EmptyContent, ct));

    public Task<ApiResponse<Unit>> RemovePromoCodeAsync() =>
        ExecuteAsync<Unit>(ct => _client.DeleteAsync("store/basket/promo-codes", ct));
}
