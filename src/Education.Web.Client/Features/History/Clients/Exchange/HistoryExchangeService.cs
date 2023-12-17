using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Exchange.Models;
using Education.Web.Client.Features.History.Clients.Exchange.Requests;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Clients.Exchange;

internal sealed class HistoryExchangeService : IHistoryExchangeClient
{
    private readonly HistoryApiClient _api;

    public HistoryExchangeService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ExchangeModel[]>> GetRatesAsync() =>
        _api.GetAsync<ExchangeModel[]>("history/exchange");

    public Task<ApiResult<Unit>> ExchangeAsync(ExchangeRequest request) =>
        _api.PostAsync<Unit, ExchangeRequest>("history/exchange", request);
}
