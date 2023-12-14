using Education.Web.Client.Features.History.Services.Exchange.Models;
using Education.Web.Client.Features.History.Services.Exchange.Requests;
using Education.Web.Client.Http;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Exchange;

internal interface IHistoryExchangeService
{
    public Task<ApiResult<ExchangeModel[]>> GetRatesAsync();

    public Task<ApiResult<Unit>> ExchangeAsync(ExchangeRequest request);
}