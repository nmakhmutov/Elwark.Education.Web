using System;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToSimpleFormat(this DateTime date)
        {
            var local = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local);
            return local.Date == DateTime.Today
                ? local.ToLongTimeString()
                : local.ToShortDateString();
        }

        public static string ToSimpleFormat(this TimeSpan span) =>
            span.TotalDays > 1
                ? span.ToString(@"dd\.hh\:mm")
                : span.ToString(@"hh\:mm\:ss");
    }
}