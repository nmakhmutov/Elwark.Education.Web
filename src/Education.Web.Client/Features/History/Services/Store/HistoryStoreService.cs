using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Features.History.Services.Store.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Store;

internal sealed class HistoryStoreService : IHistoryStoreService
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

    public Task<ApiResult<Guid>> CheckoutAsync(CheckoutRequest request) =>
        _api.PostAsync<Guid, CheckoutRequest>("history/store/checkout", request);
}
