using Education.Client.Gateways.Models.User;
using Education.Client.Model;

namespace Education.Client.Gateways.Store.Catalog
{
    public sealed record Subscription(
        string Id,
        SubscriptionType Type,
        uint Months,
        Price Price,
        SubjectType[] Subjects
    );
}
