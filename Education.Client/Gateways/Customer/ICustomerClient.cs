using System.Net.Http;
using System.Threading.Tasks;

namespace Education.Client.Gateways.Customer
{
    public interface ICustomerClient
    {
        Task CreateAsync();
    }
    
    internal sealed class CustomerClient : GatewayClient, ICustomerClient
    {
        private readonly HttpClient _client;

        public CustomerClient(HttpClient client) =>
            _client = client;

        public async Task CreateAsync()
        {
            var response = await _client.PostAsync("customers", EmptyContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
