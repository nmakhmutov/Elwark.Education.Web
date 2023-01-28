using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Order.Model;

namespace Education.Web.Client.Services.History.Order;

internal sealed class HistoryOrderService : IHistoryOrderService
{
    private readonly ApiClient _api;

    public HistoryOrderService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id) =>
        _api.GetAsync<OrderStatusModel>($"history/orders/{id}/status");
}
