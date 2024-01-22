using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store.Model;

namespace Education.Client.Features.History.Clients.Store;

internal sealed class HistoryStoreService : IHistoryStoreClient
{
    private readonly HistoryApiClient _api;

    public HistoryStoreService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ProductInventoryModel[]>> GetInventoriesAsync() =>
        _api.GetAsync<ProductInventoryModel[]>("history/store/inventories");

    public Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync() =>
        _api.GetAsync<UpcomingInventoriesModel>("history/store/inventories/upcoming");

    public Task<ApiResult<ProductBundleModel[]>> GetBundlesAsync() =>
        _api.GetAsync<ProductBundleModel[]>("history/store/bundles");

    public  Task<ApiResult<ProductOverviewModel>> GetProductAsync(string productId) =>
        _api.GetAsync<ProductOverviewModel>($"history/store/products/{productId}");
}
