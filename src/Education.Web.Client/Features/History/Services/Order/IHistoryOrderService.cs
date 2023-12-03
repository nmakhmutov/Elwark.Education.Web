using Education.Web.Client.Features.History.Services.Order.Model;
using Education.Web.Client.Features.History.Services.Order.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Order;

public interface IHistoryOrderService
{
    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id);

    public Task<ApiResult<OrderStatusModel>> CheckoutAsync(CheckoutRequest request);
}
