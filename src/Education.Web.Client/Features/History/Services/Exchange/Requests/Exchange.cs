using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.Exchange.Requests;

internal sealed record ExchangeRequest(InternalCurrency From, InternalCurrency To, uint Amount);
