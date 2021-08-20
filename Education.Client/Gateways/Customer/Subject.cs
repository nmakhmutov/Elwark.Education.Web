using System;
using Education.Client.Gateways.Models.User;
using Education.Client.Model;

namespace Education.Client.Gateways.Customer
{
    public record Subject(
        SubjectType Type,
        SubscriptionType Subscription,
        DateTime? ExpiredAt,
        Restriction TestCreation,
        Restriction TestQuestionMistakes,
        int CurrentTests
    );
}
