namespace Education.Web.Gateways.History;

public sealed record PersonBirthdayModel(int Year, uint? Month, uint? Day, string? Place)
    : HistoricalDateModel(Year, Month, Day);