namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryArticleSummary(
        string Id,
        string Title,
        string Overview,
        string? Image,
        ContentPermission Permission,
        uint? QuantityCompletedTimes,
        ContentRating Rating
    );
}
