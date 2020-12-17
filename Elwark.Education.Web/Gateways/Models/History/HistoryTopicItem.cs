namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryTopicItem(
        string TopicId,
        string Title,
        string Image,
        HistoricalSegment? Segment,
        TopicProgress? Progress
    );
}