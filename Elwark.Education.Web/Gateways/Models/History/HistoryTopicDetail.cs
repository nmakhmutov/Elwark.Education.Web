namespace Elwark.Education.Web.Gateways.Models.History
{
    public abstract record HistoryTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodTitle Period,
        TopicTest? Test,
        HistoryArticleSummary[] Articles
    );

    public sealed record HistoryPersonTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodTitle Period,
        TopicTest? Test,
        Tag[] Characteristics,
        HistoryArticleSummary[] Articles
    ) : HistoryTopicDetail(Title, Description, Image, Period, Test, Articles);
    
    public sealed record HistoryEventTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodTitle Period,
        TopicTest? Test,
        HistoricalDateRange? Dates,
        HistoryArticleSummary[] Articles
    ) : HistoryTopicDetail(Title, Description, Image, Period, Test, Articles);
}