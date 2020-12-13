using System.Globalization;
using Elwark.Education.Web.Services.History.Model;
using Microsoft.Extensions.Localization;

namespace Elwark.Education.Web.Extensions
{
    internal static class HistoricalSegmentExtensions
    {
        public static string ToString(this HistoricalSegment? segment, IStringLocalizer<App> localizer)
        {
            if (segment is null)
                return localizer["Unknown"].Value;

            if (segment.From == segment.To)
                return segment.From.ToString(localizer);

            return $"{segment.From.ToString(localizer)} - {segment.To.ToString(localizer)}";
        }

        private static string ToString(this HistoryDate? date, IStringLocalizer<App> localizer)
        {
            if (date is null)
                return localizer["Unknown"].Value;

            var day = date.Day;
            var month = date.Month.HasValue
                ? CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month.Value)
                : null;

            return $"{day} {month} {date.Year} {localizer[date.Era.ToString()].Value}";
        }
    }
}