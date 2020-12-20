using System;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToSimpleFormat(this DateTime date) =>
            date.Date == DateTime.UtcNow.Date
                ? date.ToLongTimeString()
                : date.ToShortDateString();

        public static string ToSimpleFormat(this TimeSpan span) =>
            span.TotalDays > 1
                ? span.ToString(@"dd\.hh\:mm")
                : span.ToString(@"hh\:mm\:ss");
    }
}