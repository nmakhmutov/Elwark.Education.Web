using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Exchange.Requests;

internal sealed record ExchangeRequest(InternalCurrency From, InternalCurrency To, uint Amount);
