namespace Education.Client.Features.History.Clients.Order.Model;

public enum OrderStatus
{
    Unknown = 0,
    Created = 1,
    StockConfirmed = 2,
    Paid = 3,
    Shipped = 4,
    Cancelled = 5
}
