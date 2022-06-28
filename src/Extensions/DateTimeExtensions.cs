using Education.Web.Components.Customer;

namespace Education.Web.Extensions;

public static class DateTimeExtensions
{
    public static string ToCustomerFormat(this DateTime date, DateTimeInfo info)
    {
        var local = TimeZoneInfo.ConvertTimeFromUtc(date, info.TimeZone);
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, info.TimeZone);

        return local.ToString(local.Date == now.Date ? info.TimeFormat : info.DateFormat);
    }

    public static string ToFullCustomerFormat(this DateTime date, DateTimeInfo info) =>
        TimeZoneInfo.ConvertTimeFromUtc(date, info.TimeZone).ToString(info.DateTimeFormat);

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
