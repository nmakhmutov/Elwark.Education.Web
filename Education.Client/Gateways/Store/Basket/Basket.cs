using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.Store.Basket
{
    public sealed record Basket(string? Coupon, BasketSummary Summary, BasketItem[] Items);

    public sealed record BasketItem(
        string ProductId,
        uint Quantity,
        Price Price,
        SubscriptionType Subscription,
        SubjectType[] Subjects
    );
    
    public sealed record BasketSummary(
        decimal TotalItems,
        decimal TotalDiscount,
        decimal CouponDiscount,
        decimal TotalPrice,
        Currency Currency
    );
}
