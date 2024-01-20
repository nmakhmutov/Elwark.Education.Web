namespace Education.Client.Features.History.Clients.Order.Request;

public sealed record CheckoutRequest(
    Guid IdempotencyKey,
    string ProductId,
    byte Quantity,
    CheckoutRequest.OrderTransaction Transaction
)
{
    public enum OrderTransaction
    {
        Selling = 1,
        Purchasing = 2
    }

    public static CheckoutRequest Selling(Guid idempotencyKey, string productId, byte quantity) =>
        new(idempotencyKey, productId, quantity, OrderTransaction.Selling);

    public static CheckoutRequest Purchasing(Guid idempotencyKey, string productId, byte quantity) =>
        new(idempotencyKey, productId, quantity, OrderTransaction.Purchasing);
}
