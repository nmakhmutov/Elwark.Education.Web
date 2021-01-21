namespace Elwark.Education.Web.Gateways.Models.History
{
    public record HistoricalDate(int Year, int? Month, int? Day);

    public sealed record HistoryPersonDate(int Year, int? Month, int? Day, string Place)
        : HistoricalDate(Year, Month, Day);
}