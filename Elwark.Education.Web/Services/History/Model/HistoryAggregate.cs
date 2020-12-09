namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoryAggregate(HistoryPeriodModel[] Periods, HistoryArticleItem[] Articles);
}