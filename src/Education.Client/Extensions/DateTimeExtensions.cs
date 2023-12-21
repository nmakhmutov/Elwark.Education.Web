using System.Text;
using Microsoft.Extensions.Localization;

namespace Education.Client.Extensions;

internal static class DateTimeExtensions
{
    public static string Humanize(this DateTime date, TimeZoneInfo timeZone, string dateFormat, string timeFormat)
    {
        var local = TimeZoneInfo.ConvertTimeFromUtc(date, timeZone);
        var now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

        return local.ToString(local.Date == now.Date ? timeFormat : dateFormat);
    }

    public static string Humanize(this TimeSpan span, IStringLocalizer localizer)
    {
        if (span.TotalDays > 1)
            return $"{span.Days}{localizer["Abbreviation_Days"]} {span.Hours}{localizer["Abbreviation_Hours"]}";

        if (span.TotalHours > 1)
            return $"{span.Hours}{localizer["Abbreviation_Hours"]} {span.Minutes}{localizer["Abbreviation_Minutes"]}";

        var sb = new StringBuilder();

        if (span.Minutes > 0)
            sb.Append($"{span.Minutes}{localizer["Abbreviation_Minutes"]} ");

        if (span.Seconds > 0)
            sb.Append($"{span.Seconds}{localizer["Abbreviation_Seconds"]}");

        return sb.ToString();
    }
}
