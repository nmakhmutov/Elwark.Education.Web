using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Store.Model;

namespace Education.Web.Client.Services.History.Store;

internal sealed class HistoryStoreService : IHistoryStoreService
{
    private readonly ApiClient _api;

    public HistoryStoreService(ApiClient api) =>
        _api = api;

    public Task<ApiResult<StorefrontModel>> GetAsync() =>
        _api.GetAsync<StorefrontModel>("history/store");
}
