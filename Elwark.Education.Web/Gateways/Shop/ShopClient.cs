using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Model;
using Subscription = Elwark.Education.Web.Gateways.Models.Shop.Subscription;

namespace Elwark.Education.Web.Gateways.Shop
{
    internal class ShopClient : GatewayClient, IShopClient
    {
        private readonly HttpClient _client;

        public ShopClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<Subscription[]>> GetSubscriptions() =>
            ExecuteAsync<Subscription[]>(() => _client.GetAsync("shop/catalog"));

        public Task<ApiResponse<Subscription[]>> GetSubscriptions(SubjectType subject) =>
            ExecuteAsync<Subscription[]>(() => _client.GetAsync($"shop/catalog/{subject}"));
    }
}