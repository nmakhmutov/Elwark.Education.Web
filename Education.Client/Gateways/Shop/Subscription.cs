using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.Shop
{
    public sealed record Subscription(
        string Id,
        SubscriptionType Type,
        string Title,
        string Overview,
        uint Days,
        Price[] Prices
    );
    
    public sealed record Price(string Currency, double Value, double Discount, double Total, uint DiscountPercent);
}
