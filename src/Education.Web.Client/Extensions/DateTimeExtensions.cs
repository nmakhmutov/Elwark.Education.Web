using Microsoft.Extensions.Localization;

namespace Education.Web.Client.Extensions;

public static class DateTimeExtensions
{
    public static string Humanize(this DateTime date, TimeZoneInfo timeZone, string dateFormat, string timeFormat)
    {
        var local = TimeZoneInfo.ConvertTimeFromUtc(date, timeZone);
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

        return local.ToString(local.Date == now.Date ? timeFormat : dateFormat);
    }

    public static string Humanize(this TimeSpan span, bool hideSeconds = false)
    {
        var format = span switch
        {
            { TotalDays: > 1 } => @"dd\.hh\:mm",
            { TotalHours: > 1 } => hideSeconds ? @"hh\:mm" : @"hh\:mm\:ss",
            _ => @"mm\:ss"
        };

        return span.ToString(format);
    }

    public static string Humanize(this TimeSpan span, IStringLocalizer localizer)
    {
        if (span.TotalDays > 1)
            return $"{span.Days}{localizer["Abbreviation_Days"]} {span.Hours}{localizer["Abbreviation_Hours"]}";

        if (span.TotalHours > 1)
            return $"{span.Hours}{localizer["Abbreviation_Hours"]} {span.Minutes}{localizer["Abbreviation_Minutes"]}";

        return span.TotalMinutes > 1
            ? $"{span.Minutes}{localizer["Abbreviation_Minutes"]} {span.Seconds}{localizer["Abbreviation_Seconds"]}"
            : $"{span.Seconds}{localizer["Abbreviation_Seconds"]}";
    }
}
