using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Order.Model;
using Education.Web.Client.Features.History.Clients.Order.Request;

namespace Education.Web.Client.Features.History.Clients.Order;

public interface IHistoryOrderClient
{
    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id);

    public Task<ApiResult<OrderStatusModel>> CheckoutAsync(CheckoutRequest request);
}
