using Education.Http;
using Education.Web.Client.Services.History.Order.Model;

namespace Education.Web.Client.Services.History.Order;

public interface IHistoryOrderService
{
    public Task<ApiResult<OrderStatusModel>> GetStatus(Guid id);
}
