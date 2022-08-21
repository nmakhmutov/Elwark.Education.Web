using System.Globalization;

namespace Education.Web.Components.Customer;

public sealed record CustomerState
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/v1660058875/People/default_nhpke4.svg";

    public static CustomerState Anonymous =>
        new(
            string.Empty,
            AnonymousImage,
            TimeZoneInfo.Local.Id,
            CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern,
            DateOnly.FromDateTime(DateTime.MinValue)
        );

    public static CustomerState Authenticated(string name, string image, string timezone, DayOfWeek startOfWeek,
        string dateFormat, string timeFormat, DateOnly createdAt) =>
        new(name, image, timezone, startOfWeek, dateFormat, timeFormat, createdAt);

    private CustomerState(string name, string image, string timeZone, DayOfWeek startOfWeek, string dateFormat,
        string timeFormat, DateOnly createdAt)
    {
        Name = name;
        Image = image;
        StartOfWeek = startOfWeek;
        CreatedAt = createdAt;
        DateTimeInfo = new DateTimeInfo(
            TimeZoneInfo.FindSystemTimeZoneById(timeZone),
            dateFormat,
            timeFormat,
            $"{dateFormat} {timeFormat}"
        );
    }

    public string Name { get; }

    public string Image { get; }

    public DayOfWeek StartOfWeek { get; }

    public DateTimeInfo DateTimeInfo { get; }

    public DateOnly CreatedAt { get; }
}

public sealed record DateTimeInfo(TimeZoneInfo TimeZone, string DateFormat, string TimeFormat, string DateTimeFormat);
