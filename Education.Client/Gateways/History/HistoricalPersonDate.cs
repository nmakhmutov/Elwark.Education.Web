namespace Education.Client.Gateways.History
{
    public sealed record HistoricalPersonDate(int Year, int? Month, int? Day, string? Place)
        : HistoricDate(Year, Month, Day);
}
