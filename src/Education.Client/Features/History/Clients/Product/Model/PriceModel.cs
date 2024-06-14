namespace Education.Client.Features.History.Clients.Product.Model;

public sealed record PriceModel(GameMoneyModel Original, GameMoneyModel Total, uint Discount);
