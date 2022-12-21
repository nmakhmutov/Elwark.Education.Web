namespace Education.Web.Client.Services.Customer.Model;

public sealed record CustomerModel(
    long Id,
    string FullName,
    string Image,
    string TimeZone,
    DayOfWeek StartOfWeek,
    string Language,
    string DateFormat,
    string TimeFormat,
    DateOnly CreatedAt
);