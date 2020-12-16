using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTopicItem(
        string TopicId,
        string Title,
        string Image,
        HistoricalSegment? Segment,
        TopicProgress? Progress
    );
}