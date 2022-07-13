using Education.Web.Gateways.Customers.Model;
using Education.Web.Gateways.Customers.Requests;
using Education.Web.Gateways.Models;

namespace Education.Web.Gateways.Customers;

internal interface ICustomerClient
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<TokenPaginationResponse<NotificationModel>>> GetAsync(NotificationsRequest request);

    Task<ApiResult<Unit>> MarkAllNotificationsAsReadAsync();

    Task<ApiResult<Unit>> MarkNotificationAsReadAsync(string id);
}

internal sealed class CustomerClient : GatewayClient, ICustomerClient
{
    private readonly HttpClient _client;

    public CustomerClient(HttpClient client) =>
        _client = client;

    public Task<ApiResult<CustomerModel>> GetAsync() =>
        ExecuteAsync<CustomerModel>(ct => _client.GetAsync("customers/me", ct));

    public Task<ApiResult<CustomerModel>> CreateAsync() =>
        ExecuteAsync<CustomerModel>(ct => _client.PostAsync("customers/me", null, ct));

    public Task<ApiResult<TokenPaginationResponse<NotificationModel>>> GetAsync(NotificationsRequest request)
    {
        var url = $"customers/me/notifications{request.ToQueryString()}";
        return ExecuteAsync<TokenPaginationResponse<NotificationModel>>(ct => _client.GetAsync(url, ct));
    }

    public Task<ApiResult<Unit>> MarkAllNotificationsAsReadAsync() =>
        ExecuteAsync<Unit>(ct => _client.DeleteAsync("customers/me/notifications", ct));

    public Task<ApiResult<Unit>> MarkNotificationAsReadAsync(string id) =>
        ExecuteAsync<Unit>(ct => _client.DeleteAsync($"customers/me/notifications/{id}", ct));
}
