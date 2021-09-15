using System.Net.Http;
using System.Threading.Tasks;

namespace Education.Client.Gateways.Store.Catalog
{
    internal sealed class CatalogClient : GatewayClient
    {
        private readonly HttpClient _client;

        public CatalogClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<Subscription[]>> GetSubscriptions() =>
            ExecuteAsync<Subscription[]>(() => _client.GetAsync("store/catalog/subscriptions"));

        public Task<ApiResponse<Subscription[]>> GetSubscriptions(SubjectType subject) =>
            ExecuteAsync<Subscription[]>(() => _client.GetAsync($"store/catalog/subscriptions/{subject}"));
    }
}
