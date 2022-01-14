namespace Education.Client.Gateways.History;

public sealed record HistoricalPersonBirthday(int Year, uint? Month, uint? Day, string? Place)
    : HistoricalDate(Year, Month, Day);
