using System.Globalization;
using Education.Web.Client.Extensions;
using Education.Web.Client.Features.Customer.Services.Account.Model;

namespace Education.Web.Client.Shared.State.Customer;

public sealed record CustomerState(
    string Name,
    string Image,
    TimeZoneInfo TimeZone,
    DayOfWeek StartOfWeek,
    string DateFormat,
    string TimeFormat,
    DateOnly CreatedAt
)
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/v1660058875/People/default.svg";

    public static CustomerState Anonymous =>
        new(
            string.Empty,
            AnonymousImage,
            TimeZoneInfo.Local,
            CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern,
            DateOnly.FromDateTime(DateTime.MinValue)
        );

    public static CustomerState Map(CustomerModel customer) =>
        new(
            customer.FullName,
            customer.Image,
            customer.TimeZone,
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
