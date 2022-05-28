using Education.Web.Gateways.Customers.Model;

namespace Education.Web.Gateways.Customers;

public interface ICustomerClient
{
    Task<ApiResponse<CustomerModel>> GetAsync();

    Task<ApiResponse<CustomerModel>> CreateAsync();
}

internal sealed class CustomerClient : GatewayClient, ICustomerClient
{
    private readonly HttpClient _client;

    public CustomerClient(HttpClient client) =>
        _client = client;

    public Task<ApiResponse<CustomerModel>> GetAsync() =>
        ExecuteAsync<CustomerModel>(ct => _client.GetAsync("customers/me", ct));

    public Task<ApiResponse<CustomerModel>> CreateAsync() =>
        ExecuteAsync<CustomerModel>(ct => _client.PostAsync("customers", null, ct));
}
