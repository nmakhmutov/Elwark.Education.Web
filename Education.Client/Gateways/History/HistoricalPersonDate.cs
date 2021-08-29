namespace Education.Client.Gateways.History
{
    public sealed record HistoricalPersonDate(int Year, uint? Month, uint? Day, string? Place)
        : HistoricDate(Year, Month, Day);
}
