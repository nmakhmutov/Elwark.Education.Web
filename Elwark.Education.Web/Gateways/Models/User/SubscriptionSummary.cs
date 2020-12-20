using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record SubscriptionSummary(Subject Subject, SubscriptionType Type, DateTime? ExpiredAt);
}