using Education.Http;
using Education.Web.Client.Services.History.Store.Model;

namespace Education.Web.Client.Services.History.Store;

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
