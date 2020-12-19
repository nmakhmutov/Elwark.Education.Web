using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.User
{
    internal sealed class UserClient : GatewayClient, IUserClient
    {
        private readonly HttpClient _client;

        public UserClient(HttpClient client) =>
            _client = client;

        public Task<ApiResponse<SubscriptionItem[]>> GetSubscriptionsAsync() =>
            ExecuteAsync<SubscriptionItem[]>(() => _client.GetAsync("users/me/subscriptions"));

        public Task<ApiResponse<Profile>> GetProfileAsync() =>
            ExecuteAsync<Profile>(() => _client.GetAsync("users/me"));

        public async Task CreateAsync()
        {
            var response = await _client.PostAsync("users", EmptyContent);
            response.EnsureSuccessStatusCode();
        }
    }
}