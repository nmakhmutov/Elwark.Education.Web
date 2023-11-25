using Education.Web.Client.Features.History.Services.Order.Model;
using Education.Web.Client.Features.History.Services.Order.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Order;

internal sealed class HistoryOrderService : IHistoryOrderService
{
    private readonly HistoryApiClient _api;

    public HistoryOrderService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id) =>
        _api.GetAsync<OrderStatusModel>($"history/orders/{id}/status");
    
    public Task<ApiResult<OrderStatusModel>> CheckoutAsync(CheckoutRequest request) =>
        _api.PostAsync<OrderStatusModel, CheckoutRequest>("history/orders", request);
}
