using Education.Client.Gateways.Models.User;
using Education.Client.Gateways.Store.Catalog;
using Education.Client.Model;

namespace Education.Client.Gateways.Store.Basket
{
    public sealed record Basket(string Coupon, BasketItem[] Items);
    
    public sealed record BasketItem(
        string ProductId,
        SubscriptionType Subscription,
        uint Quantity,
        Price Price,
        SubjectType[] Subjects
    );
}
