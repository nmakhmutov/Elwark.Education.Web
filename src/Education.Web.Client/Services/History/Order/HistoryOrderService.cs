using Education.Http;
using Education.Web.Client.Services.History.Order.Model;

namespace Education.Web.Client.Services.History.Order;

internal sealed class HistoryOrderService : IHistoryOrderService
{
    private readonly HistoryApiClient _api;

    public HistoryOrderService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id) =>
        _api.GetAsync<OrderStatusModel>($"history/orders/{id}/status");
}
