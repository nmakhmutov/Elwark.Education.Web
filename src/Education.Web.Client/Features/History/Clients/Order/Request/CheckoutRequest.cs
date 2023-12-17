namespace Education.Web.Client.Features.History.Clients.Order.Request;

public sealed record CheckoutRequest(Guid IdempotencyKey, string ProductId, byte Quantity);
