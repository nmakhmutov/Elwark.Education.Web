using Education.Client.Clients;
using Education.Client.Features.History.Clients.Exchange.Models;
using Education.Client.Features.History.Clients.Exchange.Requests;
using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Exchange;

internal interface IHistoryExchangeClient
{
    public Task<ApiResult<ExchangeModel[]>> GetRatesAsync();

    public Task<ApiResult<Unit>> ExchangeAsync(ExchangeRequest request);
}
