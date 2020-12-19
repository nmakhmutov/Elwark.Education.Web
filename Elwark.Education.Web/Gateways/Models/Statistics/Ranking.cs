namespace Elwark.Education.Web.Gateways.Models.Statistics
{
    public sealed record Ranking<T>(RankingItem<T>[] Bests, RankingItem<T>[] Worsts);
    
    public sealed record RankingItem<T>(string Id, string? Title, T Value);
}