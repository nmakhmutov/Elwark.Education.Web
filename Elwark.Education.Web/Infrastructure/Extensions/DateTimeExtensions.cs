using System;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
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

        public static string ToSimpleFormat(this TimeSpan span) =>
            span.TotalDays > 1
                ? span.ToString(@"dd\.hh\:mm")
                : span.Seconds > 0
                    ? span.ToString(@"hh\:mm\:ss")
                    : span.ToString(@"hh\:mm");
    }
}
