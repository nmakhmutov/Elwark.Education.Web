using System.Collections.Generic;

namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryTopicModel(
        string Title,
        string Description,
        string Image,
        string Date,
        HistoryPeriodTitle Period,
        IEnumerable<HistoryArticleItem> Articles
    );
}