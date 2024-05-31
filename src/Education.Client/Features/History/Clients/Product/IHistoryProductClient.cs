using Education.Client.Clients;
using Education.Client.Features.History.Clients.Product.Model;

namespace Education.Client.Features.History.Clients.Product;

public interface IHistoryProductClient
{
    Task<ApiResult<Model.Product[]>> GetAsync();

    Task<ApiResult<ProductOverviewModel>> GetAsync(string productId);
}
