using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Features.History.Services.Store.Request;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Store;

public interface IHistoryStoreService
{
    public Task<ApiResult<Product.InventoryModel[]>> GetInventoriesAsync();

    public Task<ApiResult<Product.BundleModel[]>> GetBundlesAsync();

    public Task<ApiResult<Guid>> CheckoutAsync(CheckoutRequest request);
}
