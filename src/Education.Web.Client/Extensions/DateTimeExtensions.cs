using System.Text;
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

    public static string Humanize(this TimeSpan span, IStringLocalizer localizer, bool hideSeconds = false)
    {
        var sb = new StringBuilder();
        
        if (span.Days > 0)
            sb.Append($"{span.Days}{localizer["Abbreviation_Days"]} ");

        if (span.Hours > 0)
            sb.Append($"{span.Hours}{localizer["Abbreviation_Hours"]} ");
        
        if(span.Minutes > 0)
            sb.Append($"{span.Minutes}{localizer["Abbreviation_Minutes"]} ");
        
        if(span.Seconds > 0 && !hideSeconds)
            sb.Append($"{span.Seconds}{localizer["Abbreviation_Seconds"]} ");

        return sb.ToString().TrimEnd();
    }
}
