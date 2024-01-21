using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store.Model;

namespace Education.Client.Features.History.Clients.Store;

public interface IHistoryStoreClient
{
    Task<ApiResult<ProductInventoryModel[]>> GetInventoriesAsync();

    Task<ApiResult<UpcomingInventoriesModel>> GetUpcomingInventoriesAsync();

    Task<ApiResult<ProductBundleModel[]>> GetBundlesAsync();

    Task<ApiResult<ProductOverviewModel>> GetProductId(string productId);
}
