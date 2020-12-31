namespace Elwark.Education.Web.Gateways.Models.History
{
    public abstract record HistoryTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodTitle Period,
        TopicTest Test,
        HistoryArticleItem[] Articles
    );

    public sealed record HistoryPersonTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodTitle Period,
        TopicTest Test,
        Tag[] Characteristics,
        HistoryArticleItem[] Articles
    ) : HistoryTopicDetail(Title, Description, Image, Period, Test, Articles);
    
    public sealed record HistoryEventTopicDetail(
        string Title,
        string Description,
        string Image,
        HistoryPeriodTitle Period,
        TopicTest Test,
        HistoricalDateRange? Dates,
        HistoryArticleItem[] Articles
    ) : HistoryTopicDetail(Title, Description, Image, Period, Test, Articles);
}