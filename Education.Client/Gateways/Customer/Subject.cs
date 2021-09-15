using System;
using Education.Client.Gateways.Models.User;

namespace Education.Client.Gateways.Customer
{
    public record Subject(
        SubjectType Type,
        SubscriptionType Subscription,
        DateTime? ExpiredAt,
        Restriction TestCreation,
        Restriction TestMistakes,
        uint CurrentTests
    );
}
