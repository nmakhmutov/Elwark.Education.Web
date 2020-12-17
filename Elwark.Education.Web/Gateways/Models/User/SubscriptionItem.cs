using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Gateways.Models.User
{
    public sealed record SubscriptionItem(Subject Subject, SubscriptionType Type, DateTime? ExpiredAt);
}