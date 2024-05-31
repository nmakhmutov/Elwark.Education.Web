using Education.Client.Models;

namespace Education.Client.Features.History.Clients.Product.Model;

public sealed record PriceModel(InternalMoneyModel Original, InternalMoneyModel Total, uint Discount);
