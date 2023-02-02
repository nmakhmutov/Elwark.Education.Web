using Education.Web.Client.Features.History.Services.Store.Model;
using Education.Web.Client.Http;

namespace Education.Web.Client.Features.History.Services.Store;

public interface IHistoryStoreService
{
    Task<ApiResult<ProductModel[]>> GetAsync();

    Task<ApiResult<Guid>> CheckoutAsync(CheckoutRequest request);
}
