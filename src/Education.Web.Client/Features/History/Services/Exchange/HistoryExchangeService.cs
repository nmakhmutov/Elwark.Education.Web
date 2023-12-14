using Education.Web.Client.Features.History.Services.Exchange.Models;
using Education.Web.Client.Features.History.Services.Exchange.Requests;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Exchange;

internal sealed class HistoryExchangeService : IHistoryExchangeService
{
    private readonly HistoryApiClient _api;

    public HistoryExchangeService(HistoryApiClient api) =>
        _api = api;

    public Task<ApiResult<ExchangeModel[]>> GetRatesAsync() =>
        _api.GetAsync<ExchangeModel[]>("history/exchange");

    public Task<ApiResult<Unit>> ExchangeAsync(ExchangeRequest request) =>
        _api.PostAsync<Unit, ExchangeRequest>("history/exchange", request);
}
