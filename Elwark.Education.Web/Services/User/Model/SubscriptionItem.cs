using System;
using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.User.Model
{
    public sealed record SubscriptionItem(Subject Subject, SubscriptionType Type, DateTime? ExpiredAt);
}