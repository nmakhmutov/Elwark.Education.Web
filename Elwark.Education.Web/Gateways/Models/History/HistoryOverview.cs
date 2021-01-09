namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryOverview(
        HistoryPeriodModel[] Periods,
        Ratings<RatingArticleOverview> Articles,
        Ratings<RatingTopicOverview> Topics
    );

    public sealed record Ratings<T>(T[] Trends, T[] Recent);

    public sealed record RatingArticleOverview(
        string Id,
        string Title,
        string Overview,
        string? Image,
        ContentPermission Permission
    );
    
    public sealed record RatingTopicOverview(
        string Id,
        string Title,
        string Overview,
        string Image
    );
}