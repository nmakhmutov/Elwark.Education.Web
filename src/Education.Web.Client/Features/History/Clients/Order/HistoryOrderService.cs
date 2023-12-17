using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Order.Model;
using Education.Web.Client.Features.History.Clients.Order.Request;

namespace Education.Web.Client.Features.History.Clients.Order;

internal sealed class HistoryOrderService : IHistoryOrderClient
{
    private readonly HistoryApiClient _api;

    public HistoryOrderService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id) =>
        _api.GetAsync<OrderStatusModel>($"history/orders/{id}/status");

    public Task<ApiResult<OrderStatusModel>> CheckoutAsync(CheckoutRequest request) =>
        _api.PostAsync<OrderStatusModel, CheckoutRequest>("history/orders", request);
}
