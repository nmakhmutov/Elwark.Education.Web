using Elwark.Education.Web.Model;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryArticleModel(
        string Id,
        HistoryTopicTitle Topic,
        HistoryPeriodTitle Period,
        ArticleType Type,
        string? Image,
        string Title,
        string? Subtitle,
        string Text,
        string? Footnotes,
        bool IsAvailableTest
    );
}