using System.Net.Http;
using System.Threading.Tasks;
using Education.Client.Gateways.Models;

namespace Education.Client.Gateways.Store.Basket
{
    internal sealed class BasketClient : GatewayClient
    {
        private readonly HttpClient _client;

        public BasketClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<Basket>> GetAsync() =>
            ExecuteAsync<Basket>(() => _client.GetAsync("store/basket"));

        public Task<ApiResponse<Unit>> AddItemAsync(string productId) =>
            ExecuteAsync<Unit>(() => _client.PutAsync($"store/basket/items/{productId}", EmptyContent));
        
        public Task<ApiResponse<Unit>> RemoveItemAsync(string productId) =>
            ExecuteAsync<Unit>(() => _client.DeleteAsync($"store/basket/items/{productId}"));
        
        public Task<ApiResponse<Unit>> AddCouponAsync(string coupon) =>
            ExecuteAsync<Unit>(() => _client.PutAsync($"store/basket/coupons/{coupon}", EmptyContent));
        
        public Task<ApiResponse<Unit>> RemoveCouponAsync() =>
            ExecuteAsync<Unit>(() => _client.DeleteAsync($"store/basket/coupons"));
    }
}
