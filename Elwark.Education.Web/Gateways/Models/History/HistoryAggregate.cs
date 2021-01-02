namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoryAggregate(HistoryPeriodModel[] Periods, HistoryArticleSummary[] Articles);
}