namespace Education.Web.Extensions;

public static class DateTimeExtensions
{
    public static string ToSimpleFormat(this DateTime date)
    {
        var local = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);

        if (local.Date != DateTime.Today)
            return local.ToShortDateString();

        return local.Second == 0
            ? local.ToShortTimeString()
            : local.ToLongTimeString();
    }

    public static string ToSimpleFormat(this TimeSpan span, bool hideSeconds = false)
    {
        var format = span switch
        {
            { TotalDays: > 1 } => @"dd\.hh\:mm",
            { TotalHours: > 1 } => hideSeconds ? @"hh\:mm" : @"hh\:mm\:ss",
            _ => @"mm\:ss"
        };

        return span.ToString(format);
    }
}
