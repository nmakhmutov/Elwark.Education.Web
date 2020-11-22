using System;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record Subscription(SubscriptionType Type, DateTime? ExpiredAt);
}