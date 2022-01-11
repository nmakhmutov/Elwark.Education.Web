using Education.Client.Gateways.Models;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.Store.Catalog;

public sealed record Subscription(
    string Id,
    SubscriptionType Type,
    uint Months,
    Money Price,
    SubjectType[] Subjects
);
