namespace Education.Client.Features.History.Clients.Exchange.Models;

public sealed record ExchangeModel(InternalCurrency From, InternalCurrency To, double Rate, uint ConversionFactor);
