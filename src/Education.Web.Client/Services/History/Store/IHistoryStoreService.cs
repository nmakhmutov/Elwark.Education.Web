using Education.Web.Client.Services.Api;
using Education.Web.Client.Services.History.Store.Model;

namespace Education.Web.Client.Services.History.Store;

public interface IHistoryStoreService
{
    Task<ApiResult<StorefrontModel>> GetAsync();
}