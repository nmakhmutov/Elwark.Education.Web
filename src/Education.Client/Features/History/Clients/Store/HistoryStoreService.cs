using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store.Model;

namespace Education.Client.Features.History.Clients.Store;

internal sealed class HistoryStoreService : IHistoryStoreClient
{
    private const string Root = "history/store";
    private readonly HistoryApiClient _api;

    public HistoryStoreService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ProductInventory[]>> GetInventoriesAsync() =>
        _api.GetAsync<ProductInventory[]>($"{Root}/inventories");

    public Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync() =>
        _api.GetAsync<UpcomingInventoriesModel>($"{Root}/inventories/upcoming");

    public Task<ApiResult<ProductBundleModel[]>> GetBundlesAsync() =>
        _api.GetAsync<ProductBundleModel[]>($"{Root}/bundles");

    public Task<ApiResult<ProductOverviewModel>> GetProductAsync(string productId) =>
        _api.GetAsync<ProductOverviewModel>($"{Root}/products/{productId}");
}
