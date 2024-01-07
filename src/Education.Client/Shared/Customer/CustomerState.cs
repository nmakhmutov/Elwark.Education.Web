using System.Globalization;
using Education.Client.Extensions;
using Education.Client.Features.Customer.Services.Account.Model;

namespace Education.Client.Shared.Customer;

public sealed record CustomerState(
    string Name,
    string Image,
    TimeZoneInfo TimeZone,
    string Language,
    DayOfWeek StartOfWeek,
    string DateFormat,
    string TimeFormat,
    DateOnly CreatedAt
)
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/f_auto,q_auto/v1/People/default.svg";

    public static CustomerState Anonymous =>
        new(
            string.Empty,
            AnonymousImage,
            TimeZoneInfo.Local,
            CultureInfo.CurrentCulture.TwoLetterISOLanguageName,
            CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern,
            DateOnly.MinValue
        );

    public static CustomerState Map(CustomerModel customer) =>
        new(
            customer.FullName,
            customer.Image,
            customer.TimeZone,
            customer.Language,
            customer.StartOfWeek,
            customer.DateFormat,
            customer.TimeFormat,
            customer.CreatedAt
        );

    public string Humanize(DateOnly date) =>
        date.ToString(DateFormat);

    public string Humanize(DateTime dateTime) =>
        dateTime.Humanize(TimeZone, DateFormat, TimeFormat);
}
