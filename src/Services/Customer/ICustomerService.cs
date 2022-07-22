using Education.Web.Services.Api;
using Education.Web.Services.Customer.Model;
using Education.Web.Services.Customer.Request;
using Education.Web.Services.Model;

namespace Education.Web.Services.Customer;

internal interface ICustomerService
{
    Task<ApiResult<CustomerModel>> GetAsync();

    Task<ApiResult<CustomerModel>> CreateAsync();

    Task<ApiResult<TokenPaginationResponse<NotificationModel>>> GetAsync(NotificationsRequest request);

    Task<ApiResult<Unit>> MarkAllNotificationsAsReadAsync();

    Task<ApiResult<Unit>> MarkNotificationAsReadAsync(string id);
}