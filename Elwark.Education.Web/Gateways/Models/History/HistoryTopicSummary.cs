namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTopicSummary(
        string Id,
        string Title,
        string Overview,
        string Image,
        TopicProgress? Progress
    );
}