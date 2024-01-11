using Education.Client.Clients;
using Education.Client.Features.History.Clients.Order.Model;
using Education.Client.Features.History.Clients.Order.Request;

namespace Education.Client.Features.History.Clients.Order;

public interface IHistoryOrderClient
{
    Task<ApiResult<OrderStatusModel>> GetStatus(Guid id);

    Task<ApiResult<OrderStatusModel>> CheckoutAsync(CheckoutRequest request);
}
