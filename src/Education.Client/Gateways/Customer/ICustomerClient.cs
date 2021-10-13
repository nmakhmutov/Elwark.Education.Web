using System.Net.Http;
using System.Threading.Tasks;

namespace Education.Client.Gateways.Customer;

public interface ICustomerClient
{
    Task<ApiResponse<Customer>> GetAsync();
        
    Task CreateAsync();
}
    
internal sealed class CustomerClient : GatewayClient, ICustomerClient
{
    private readonly HttpClient _client;

    public CustomerClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<Customer>> GetAsync() =>
        ExecuteAsync<Customer>(() => _client.GetAsync("customers/me"));

    public async Task CreateAsync()
    {
        var response = await _client.PostAsync("customers", EmptyContent);
        response.EnsureSuccessStatusCode();
    }
}