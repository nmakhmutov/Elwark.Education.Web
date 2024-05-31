using Education.Client.Clients;
using Education.Client.Features.History.Clients.Product.Model;

namespace Education.Client.Features.History.Clients.Product;

internal sealed class HistoryProductService : IHistoryProductClient
{
    private const string Root = "history/products";
    private readonly HistoryApiClient _api;

    public HistoryProductService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<Model.Product[]>> GetAsync() =>
        _api.GetAsync<Model.Product[]>(Root);

    public Task<ApiResult<ProductOverviewModel>> GetAsync(string productId) =>
        _api.GetAsync<ProductOverviewModel>($"{Root}/{productId}");
}
