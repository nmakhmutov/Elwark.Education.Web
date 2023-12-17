using Education.Web.Client.Clients;
using Education.Web.Client.Features.History.Clients.Exchange.Models;
using Education.Web.Client.Features.History.Clients.Exchange.Requests;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Clients.Exchange;

internal interface IHistoryExchangeClient
{
    public Task<ApiResult<ExchangeModel[]>> GetRatesAsync();

    public Task<ApiResult<Unit>> ExchangeAsync(ExchangeRequest request);
}
