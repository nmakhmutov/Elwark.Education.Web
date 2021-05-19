namespace Elwark.Education.Web.Gateways.Models.History
{
    public abstract record HistoryTopicDetail(
        string Id,
        string Title,
        string Description,
        string Image,
        EpochType Epoch,
        TopicTest Test,
        ContentRating Rating,
        bool IsFavorite,
        Chapter[] Chapters,
        Infobox[] InfoBoxes,
        TopicSummary[] RelatedTopics
    );

    public sealed record HistoryPersonTopicDetail(
        string Id,
        string Title,
        string Description,
        string Image,
        EpochType Epoch,
        TopicTest Test,
        HistoricalPersonDate? Born,
        HistoricalPersonDate? Died,
        ContentRating Rating,
        bool IsFavorite,
        Chapter[] Content,
        Infobox[] InfoBoxes,
        string[] Occupations,
        Infobox[] Characteristics,
        TopicSummary[] RelatedTopics
    ) : HistoryTopicDetail(Id, Title, Description, Image, Epoch, Test, Rating, IsFavorite, Content, InfoBoxes, RelatedTopics);

    public sealed record HistoryEventTopicDetail(
        string Id,
        string Title,
        string Description,
        string Image,
        EpochType Epoch,
        TopicTest Test,
        HistoricDate? Started,
        HistoricDate? Ended,
        ContentRating Rating,
        bool IsFavorite,
        Chapter[] Content,
        Infobox[] InfoBoxes,
        TopicSummary[] RelatedTopics
    ) : HistoryTopicDetail(Id, Title, Description, Image, Epoch, Test, Rating, IsFavorite, Content, InfoBoxes, RelatedTopics);
}
