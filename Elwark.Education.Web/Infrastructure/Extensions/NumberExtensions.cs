using System;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class NumberExtensions
    {
        private static readonly char[] Prefixes = {'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y'};

        public static string ToReadable(this int number, string? format = null) =>
            ToReadable((double) number, format);
        
        public static string ToReadable(this uint number, string? format = null) =>
            ToReadable((double) number, format);

        public static string ToReadable(this long number, string? format = null) =>
            ToReadable((double) number, format);
        
        public static string ToReadable(this ulong number, string? format = null) =>
            ToReadable((double) number, format);

        public static string ToReadable(this double number, string? format = null)
        {
            if (number == 0)
                return number.ToString(format);
            
            var degree = (int) Math.Floor(Math.Log10(Math.Abs(number)) / 3);
            var scaled = number * Math.Pow(1000, -degree);
            var prefix = Math.Sign(degree) switch
            {
                1 => Prefixes[degree - 1],
                -1 => Prefixes[-degree - 1],
                _ => ' '
            };
            
            return $"{scaled.ToString(format)}{prefix}";
        }
    }
}