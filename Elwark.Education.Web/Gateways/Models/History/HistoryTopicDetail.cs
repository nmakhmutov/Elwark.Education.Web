using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public abstract record HistoryTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodType Period,
        TopicTest? Test,
        TopicSummary[] RelatedTopics,
        HistoryArticleSummary[] Articles
    );

    public sealed record HistoryPersonTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodType Period,
        TopicTest? Test,
        HistoryPersonDate? Born,
        HistoryPersonDate? Died,
        string[] Occupations,
        KeyValuePair<string, string>[] Characteristics,
        TopicSummary[] RelatedTopics,
        HistoryArticleSummary[] Articles
    ) : HistoryTopicDetail(Title, Description, Image, Period, Test, RelatedTopics, Articles);

    public sealed record HistoryEventTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodType Period,
        TopicTest? Test,
        HistoricalDate? Started,
        HistoricalDate? Ended,
        TopicSummary[] RelatedTopics,
        HistoryArticleSummary[] Articles
    ) : HistoryTopicDetail(Title, Description, Image, Period, Test, RelatedTopics, Articles);
}