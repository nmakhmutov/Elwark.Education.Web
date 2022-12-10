using System.Globalization;

namespace Education.Web.Components.Customer;

public sealed record CustomerState
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/v1660058875/People/default_nhpke4.svg";

    private CustomerState(string name, string image, string timeZone, DayOfWeek startOfWeek, string dateFormat,
        string timeFormat, DateOnly createdAt)
    {
        Name = name;
        Image = image;
        StartOfWeek = startOfWeek;
        CreatedAt = createdAt;
        DateTimeInfo =  DateTimeInfo.Create(timeZone, dateFormat, timeFormat);
    }

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

    public string Name { get; }

    public string Image { get; }

    public DayOfWeek StartOfWeek { get; }

    public DateTimeInfo DateTimeInfo { get; }

    public DateOnly CreatedAt { get; }

    public static CustomerState Authenticated(string name, string image, string timezone, DayOfWeek startOfWeek,
        string dateFormat, string timeFormat, DateOnly createdAt) =>
        new(name, image, timezone, startOfWeek, dateFormat, timeFormat, createdAt);
}

public sealed record DateTimeInfo
{
    private DateTimeInfo(TimeZoneInfo timeZone, string dateFormat, string timeFormat, string dateTimeFormat)
    {
        TimeZone = timeZone;
        DateFormat = dateFormat;
        TimeFormat = timeFormat;
        DateTimeFormat = dateTimeFormat;
    }

    public TimeZoneInfo TimeZone { get; }

    public string DateFormat { get; }

    public string TimeFormat { get; }

    public string DateTimeFormat { get; }

    public static DateTimeInfo Create(string timeZone, string dateFormat, string timeFormat) =>
        new(TimeZoneInfo.FindSystemTimeZoneById(timeZone), dateFormat, timeFormat, $"{dateFormat} {timeFormat}");
}

