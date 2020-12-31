using System;
using System.Linq;

namespace Elwark.Education.Web.Gateways.Models.History
{
    public sealed record HistoricalDate(Era Era, int Year, int? Month, int? Day)
    {
        public static HistoricalDate? FromString(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            var result = value.Split('.');
            var date = result[0].Split('-').Select(int.Parse).ToArray();

            return new HistoricalDate(
                Enum.Parse<Era>(result[1], true),
                date[0],
                date[1] == 0 ? null : date[1],
                date[2] == 0 ? null : date[2]
            );
        }
    }

    public enum Era
    {
        Bc = -1,
        Ad = 1
    }
}