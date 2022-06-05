using System.Globalization;

namespace Education.Web.Components.Customer;

internal sealed class CustomerState
{
    private const string AnonymousImage =
        "https://res.cloudinary.com/elwark/image/upload/v1610430646/People/default_j21xml.png";

    public static CustomerState Anonymous =>
        new(
            false,
            0,
            string.Empty,
            AnonymousImage,
            TimeZoneInfo.Local.Id,
            DayOfWeek.Monday,
            CultureInfo.CurrentCulture.TwoLetterISOLanguageName,
            "yyyy-MM-dd",
            "HH:mm"
        );

    public static CustomerState Authenticated(long id, string name, string image, string timezone, DayOfWeek weekStart,
        string language, string dateFormat, string timeFormat) =>
        new(true, id, name, image, timezone, weekStart, language, dateFormat, timeFormat);

    private CustomerState(bool isAuthenticated, long id, string name, string image, string timeZone,
        DayOfWeek weekStart, string language, string dateFormat, string timeFormat)
    {
        IsAuthenticated = isAuthenticated;
        Id = id;
        Name = name;
        Image = image;
        TimeZone = timeZone;
        WeekStart = weekStart;
        Language = language;
        DateFormat = dateFormat;
        TimeFormat = timeFormat;
    }

    public bool IsAuthenticated { get; }

    public long Id { get; }

    public string Name { get; }

    public string Image { get; }

    public string TimeZone { get; }

    public DayOfWeek WeekStart { get; }

    public string Language { get; }

    public string DateFormat { get; }

    public string TimeFormat { get; }
}
