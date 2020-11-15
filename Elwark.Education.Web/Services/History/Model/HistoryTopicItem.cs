using System;

namespace Elwark.Education.Web.Services.History.Models
{
    public sealed record HistoryTopicItem(
        string TopicId,
        string Title,
        Uri Image,
        string? Range,
        LearningProgress? Progress
    );
}