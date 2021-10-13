using System;

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

    public static string ToLongFormat(this TimeSpan span) =>
        span.ToString(span.TotalDays > 1 ? @"dd\.hh\:mm" : @"hh\:mm\:ss");

    public static string ToShortFormat(this TimeSpan span) =>
        span.ToString(span.TotalSeconds switch
        {
            < 3600 => @"mm\:ss", // less then one hour
            < 86400 => @"hh\:mm\:ss", // less then one day
            _ => @"dd\.hh\:mm"
        });
}
