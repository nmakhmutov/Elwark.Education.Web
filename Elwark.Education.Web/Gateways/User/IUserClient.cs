using System.Net.Http;
using System.Threading.Tasks;

namespace Elwark.Education.Web.Gateways.User
{
    public interface IUserClient
    {
        Task CreateAsync();
    }
    
    internal sealed class UserClient : GatewayClient, IUserClient
    {
        private readonly HttpClient _client;

        public UserClient(HttpClient client) =>
            _client = client;

        public async Task CreateAsync()
        {
            var response = await _client.PostAsync("users", EmptyContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
