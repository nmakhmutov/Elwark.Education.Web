namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTopicItem(
        string TopicId,
        string Title,
        string Image,
        string? Range,
        LearningProgress? Progress
    );
}