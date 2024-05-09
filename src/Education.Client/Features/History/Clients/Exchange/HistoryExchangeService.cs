using Education.Client.Clients;
using Education.Client.Features.History.Clients.Exchange.Models;
using Education.Client.Features.History.Clients.Exchange.Requests;
using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Exchange;

internal sealed class HistoryExchangeService : IHistoryExchangeClient
{
    private readonly HistoryApiClient _api;
    private const string Root = "history/exchange";

    public HistoryExchangeService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ExchangeModel[]>> GetRatesAsync() =>
        _api.GetAsync<ExchangeModel[]>(Root);

    public Task<ApiResult<Unit>> ExchangeAsync(ExchangeRequest request) =>
        _api.PostAsync<Unit, ExchangeRequest>(Root, request);
}
