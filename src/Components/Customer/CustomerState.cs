using System.Globalization;

namespace Education.Web.Components.Customer;

public sealed record CustomerState
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/v1610430646/People/default_j21xml.png";

    public static CustomerState Anonymous =>
        new(
            false,
            string.Empty,
            AnonymousImage,
            TimeZoneInfo.Local.Id,
            CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek,
            CultureInfo.CurrentCulture.TwoLetterISOLanguageName,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
            CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern
        );

    public static CustomerState Authenticated(string name, string image, string timezone, DayOfWeek startOfWeek,
        string language, string dateFormat, string timeFormat) =>
        new(true, name, image, timezone, startOfWeek, language, dateFormat, timeFormat);

    private CustomerState(bool isAuthenticated, string name, string image, string timeZone,
        DayOfWeek startOfWeek, string language, string dateFormat, string timeFormat)
    {
        IsAuthenticated = isAuthenticated;
        Name = name;
        Image = image;
        StartOfWeek = startOfWeek;
        Language = language;
        DateTimeInfo = new DateTimeInfo(
            TimeZoneInfo.FindSystemTimeZoneById(timeZone),
            dateFormat,
            timeFormat,
            $"{dateFormat} {timeFormat}"
        );
    }

    public bool IsAuthenticated { get; }

    public string Name { get; }

    public string Image { get; }

    public DayOfWeek StartOfWeek { get; }

    public string Language { get; }

    public DateTimeInfo DateTimeInfo { get; }
}

public sealed record DateTimeInfo(TimeZoneInfo TimeZone, string DateFormat, string TimeFormat, string DateTimeFormat);
