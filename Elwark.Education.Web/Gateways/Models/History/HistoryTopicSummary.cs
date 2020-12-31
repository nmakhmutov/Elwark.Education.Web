namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTopicSummary(
        string Id,
        string Title,
        string Caption,
        string Image,
        TopicProgress? Progress
    );
}