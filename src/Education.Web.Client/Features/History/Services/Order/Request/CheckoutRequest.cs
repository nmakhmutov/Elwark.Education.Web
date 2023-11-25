namespace Education.Web.Client.Features.History.Services.Order.Request;

public sealed record CheckoutRequest(Guid IdempotencyKey, string ProductId, byte Quantity);
