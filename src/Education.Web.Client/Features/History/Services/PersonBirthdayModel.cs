namespace Education.Web.Client.Features.History.Services;

public sealed record PersonBirthdayModel(int Year, uint? Month, uint? Day, string? Place)
    : HistoricalDateModel(Year, Month, Day);
