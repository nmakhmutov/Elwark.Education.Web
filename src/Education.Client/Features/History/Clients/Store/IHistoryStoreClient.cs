using Education.Client.Clients;
using Education.Client.Features.History.Clients.Store.Model;

namespace Education.Client.Features.History.Clients.Store;

public interface IHistoryStoreClient
{
    Task<ApiResult<ProductInventory[]>> GetInventoriesAsync();

    Task<ApiResult<ProductBundleModel[]>> GetBundlesAsync();

    Task<ApiResult<ProductOverviewModel>> GetProductAsync(string productId);
}
