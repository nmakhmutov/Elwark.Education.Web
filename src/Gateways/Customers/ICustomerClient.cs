using Education.Web.Gateways.Customers.Model;

namespace Education.Web.Gateways.Customers;

public interface ICustomerClient
{
    Task<ApiResponse<CustomerModel>> GetAsync();

    Task CreateAsync();
}

internal sealed class CustomerClient : GatewayClient, ICustomerClient
{
    private readonly HttpClient _client;

    public CustomerClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<CustomerModel>> GetAsync() =>
        ExecuteAsync<CustomerModel>(ct => _client.GetAsync("customers/me", ct));

    public async Task CreateAsync()
    {
        var response = await _client.PostAsync("customers", null);
        response.EnsureSuccessStatusCode();
    }
}
