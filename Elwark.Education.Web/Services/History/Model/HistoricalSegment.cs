namespace Elwark.Education.Web.Services.History.Model
{
    public sealed record HistoricalSegment(HistoryDate? From, HistoryDate? To);

    public sealed record HistoryDate(int? Day, int? Month, int Year, Era Era);

    public enum Era
    {
        Bc = 0,
        Ad = 1
    }
}