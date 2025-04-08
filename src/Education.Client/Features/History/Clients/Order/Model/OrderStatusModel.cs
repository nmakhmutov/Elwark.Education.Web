namespace Education.Client.Features.History.Clients.Order.Model;

public sealed record OrderStatusModel(Guid Id, OrderStatus Status)
{
    public int Progress =>
        Status switch
        {
            OrderStatus.Created => 25,
            OrderStatus.StockConfirmed => 50,
            OrderStatus.Paid => 75,
            OrderStatus.Shipped => 100,
            OrderStatus.Cancelled => 100,
            _ => 0
        };

    public bool IsRejected =>
        Status is OrderStatus.Cancelled;

    public bool IsFinal =>
        Status is OrderStatus.Shipped or OrderStatus.Cancelled;
}
