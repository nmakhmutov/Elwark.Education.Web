namespace Education.Web.Client.Features.Customer.Services.Account.Model;

public sealed record CustomerModel(
    long Id,
    string FullName,
    string Image,
    TimeZoneInfo TimeZone,
    DayOfWeek StartOfWeek,
    string Language,
    string DateFormat,
    string TimeFormat,
    DateOnly CreatedAt
);
