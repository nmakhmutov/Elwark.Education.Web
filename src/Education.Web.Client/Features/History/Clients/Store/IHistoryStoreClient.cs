using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Store.Model;

namespace Education.Web.Client.Features.History.Clients.Store;

public interface IHistoryStoreClient
{
    public Task<ApiResult<Product.InventoryModel[]>> GetInventoriesAsync();

    Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync();

    public Task<ApiResult<Product.BundleModel[]>> GetBundlesAsync();
}
