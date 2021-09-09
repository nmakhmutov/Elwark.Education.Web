using Education.Client.Gateways.Models.User;
using Education.Client.Model;

namespace Education.Client.Gateways.Store.Catalog
{
    public sealed record Subscription(string Id, SubscriptionType Type, uint Months, Price Price, SubjectType[] Subjects);

    public sealed record Price(decimal Amount, decimal Discount, decimal Total, Currency Currency);

    public enum Currency
    {
        Usd = 0,
        Eur = 1,
        Rub = 2
    }
}
