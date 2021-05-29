using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.Shop
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
