namespace Education.Client.Extensions;

public static class DateTimeExtensions
{
    public static string ToSimpleFormat(this DateTime date)
    {
        var local = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);
        
        return local.Date == DateTime.Today
            ? local.Second > 0
                ? local.ToLongTimeString()
                : local.ToShortTimeString()
            : local.ToShortDateString();
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
