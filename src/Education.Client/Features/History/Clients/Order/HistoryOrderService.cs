using Education.Client.Clients;
using Education.Client.Features.History.Clients.Order.Model;
using Education.Client.Features.History.Clients.Order.Request;

namespace Education.Client.Features.History.Clients.Order;

internal sealed class HistoryOrderService : IHistoryOrderClient
{
    private const string Root = "history/orders";
    private readonly HistoryApiClient _api;

    public HistoryOrderService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id) =>
        _api.GetAsync<OrderStatusModel>($"{Root}/{id}/status");

    public Task<ApiResult<OrderStatusModel>> CheckoutAsync(CheckoutRequest request) =>
        _api.PostAsync<OrderStatusModel, CheckoutRequest>(Root, request);
}
