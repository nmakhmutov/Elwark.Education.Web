namespace Elwark.Education.Web.Gateways.Models.History
{
    public record HistoricDate(int Year, int? Month, int? Day);

    public sealed record HistoricalPersonDate(int Year, int? Month, int? Day, string? Place)
        : HistoricDate(Year, Month, Day);
}
