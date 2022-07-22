using Education.Web.Services.Api;
using Education.Web.Services.Customer.Model;
using Education.Web.Services.Customer.Request;
using Education.Web.Services.Model;

namespace Education.Web.Services.Customer;

internal sealed class CustomerService : ICustomerService
{
    private readonly ApiClient _api;

    public CustomerService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<CustomerModel>> GetAsync() =>
        _api.GetAsync<CustomerModel>("customers/me");

    public Task<ApiResult<CustomerModel>> CreateAsync() =>
        _api.PostAsync<CustomerModel>("customers/me");

    public Task<ApiResult<TokenPaginationResponse<NotificationModel>>> GetAsync(NotificationsRequest request) =>
        _api.GetAsync<TokenPaginationResponse<NotificationModel>>($"customers/me/notifications{request.ToQueryString()}");

    public Task<ApiResult<Unit>> MarkAllNotificationsAsReadAsync() =>
        _api.DeleteAsync("customers/me/notifications");

    public Task<ApiResult<Unit>> MarkNotificationAsReadAsync(string id) =>
        _api.DeleteAsync($"customers/me/notifications/{id}");
}
