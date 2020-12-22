using System;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record RankingItem<T>(string Id, string? Title, T Value, DateTime CreatedAt);
}