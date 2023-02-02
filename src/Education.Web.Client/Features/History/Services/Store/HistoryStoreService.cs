using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Store;

internal sealed class HistoryStoreService : IHistoryStoreService
{
    private readonly HistoryApiClient _api;

    public HistoryStoreService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ProductModel[]>> GetAsync() =>
        _api.GetAsync<ProductModel[]>("history/store");

    public Task<ApiResult<Guid>> CheckoutAsync(CheckoutRequest request) =>
        _api.PostAsync<Guid, CheckoutRequest>("history/store/checkout", request);
}
