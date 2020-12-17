using System.Collections.Generic;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryAggregate(IEnumerable<HistoryPeriodModel> Periods, IEnumerable<HistoryArticleItem> Articles);
}