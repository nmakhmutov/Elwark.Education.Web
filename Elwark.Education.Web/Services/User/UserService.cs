using System.Net.Http;
using System.Threading.Tasks;
using Elwark.Education.Web.Services.User.Model;

namespace Elwark.Education.Web.Services.User
{
    public sealed class UserService : GatewayClient, IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client) =>
            _client = client;

        public async Task<ApiResponse<SubscriptionItem[]>> GetSubscriptionsAsync()
        {
            var response = await _client.GetAsync("users/me/subscriptions");

            return await ToApiResponse<SubscriptionItem[]>(response);
        }

        public async Task<ApiResponse<Profile>> GetProfileAsync()
        {
            var response = await _client.GetAsync("users/me");

            return await ToApiResponse<Profile>(response);
        }

        public async Task CreateAsync()
        {
            var response = await _client.PostAsync("users", EmptyContent);
            response.EnsureSuccessStatusCode();
        }
    }
}