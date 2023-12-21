using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store.Model;

namespace Education.Client.Features.History.Clients.Store;

public interface IHistoryStoreClient
{
    public Task<ApiResult<Product.InventoryModel[]>> GetInventoriesAsync();

    Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync();

    public Task<ApiResult<Product.BundleModel[]>> GetBundlesAsync();
}
