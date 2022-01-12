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

    public static string ToSimpleFormat(this TimeSpan span)
    {
        var format = span switch
        {
            { TotalDays: >= 1 } => @"dd\.hh\:mm",
            { TotalHours: >= 1, TotalSeconds: 0 } => @"hh\:mm",
            { TotalHours: >= 1, TotalSeconds: > 0 } => @"hh\:mm\:ss",
            { TotalMilliseconds: 0 } => @"mm\:ss",
            _ => @"mm\:ss"
        };

        return span.ToString(format);
    }
}
