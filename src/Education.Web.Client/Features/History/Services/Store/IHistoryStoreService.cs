using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Store;

public interface IHistoryStoreService
{
    public Task<ApiResult<Product.InventoryModel[]>> GetInventoriesAsync();

    Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync();

    public Task<ApiResult<Product.BundleModel[]>> GetBundlesAsync();
}
