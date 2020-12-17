using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    internal sealed record Ranking<T>(IEnumerable<RankingItem<T>> Bests, IEnumerable<RankingItem<T>> Worsts);
    
    internal sealed record RankingItem<T>(string Id, string? Title, T Value);
}