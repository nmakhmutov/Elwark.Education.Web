using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store.Model;

namespace Education.Client.Features.History.Clients.Store;

internal sealed class HistoryStoreService : IHistoryStoreClient
{
    private readonly HistoryApiClient _api;

    public HistoryStoreService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<Product.InventoryModel[]>> GetInventoriesAsync() =>
        _api.GetAsync<Product.InventoryModel[]>("history/store/inventories");

    public Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync() =>
        _api.GetAsync<UpcomingInventoriesModel>("history/store/inventories/upcoming");

    public Task<ApiResult<Product.BundleModel[]>> GetBundlesAsync() =>
        _api.GetAsync<Product.BundleModel[]>("history/store/bundles");
}
