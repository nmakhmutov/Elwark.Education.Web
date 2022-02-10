using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.Store.Basket;

public sealed record Basket(string? PromoCode, BasketOverview Overview, BasketItem[] Items);

public sealed record BasketItem(
    string ProductId,
    uint Quantity,
    Money Price,
    Money Discount,
    Money Total,
    SubscriptionType Subscription,
    SubjectType[] Subjects
);

public sealed record BasketOverview(Money Items, Money Discount, Money Promo, Money Total);
