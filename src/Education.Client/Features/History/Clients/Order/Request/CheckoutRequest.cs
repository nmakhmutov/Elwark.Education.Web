using Education.Client.Features.History.Clients.Order.Model;

namespace Education.Client.Features.History.Clients.Order.Request;

public sealed record CheckoutRequest(Guid IdempotencyKey, string ProductId, byte Quantity, OrderType Type)
{
    public static CheckoutRequest Selling(Guid idempotencyKey, string productId, byte quantity) =>
        new(idempotencyKey, productId, quantity, OrderType.Selling);

    public static CheckoutRequest Purchasing(Guid idempotencyKey, string productId, byte quantity) =>
        new(idempotencyKey, productId, quantity, OrderType.Purchasing);
}
