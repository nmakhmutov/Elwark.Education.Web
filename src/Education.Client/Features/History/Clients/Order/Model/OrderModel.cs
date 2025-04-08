namespace Education.Client.Features.History.Clients.Order.Model;

public sealed record OrderModel(
    string OrderId,
    OrderStatus Status,
    OrderType Type,
    DateTime CreatedAt,
    OrderModel.ItemModel[] Items
)
{
    public sealed record ItemModel(string Title, GameCurrency Currency, uint Amount, uint Quantity);
}
