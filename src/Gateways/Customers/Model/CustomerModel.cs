namespace Education.Web.Gateways.Customers.Model;

public sealed record CustomerModel(
    long Id,
    string FullName,
    string Image,
    string TimeZone,
    DayOfWeek WeekStart,
    string Language,
    string DateFormat,
    string TimeFormat
);
