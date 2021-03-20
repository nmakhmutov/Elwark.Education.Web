using System;

namespace Elwark.Education.Web.Infrastructure.Extensions
{
    public static class NumberExtensions
    {
        private static readonly char[] Prefixes = {'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y'};

        public static string ToReadable(this int number) =>
            ToReadable((double) number);
        
        public static string ToReadable(this uint number) =>
            ToReadable((double) number);

        public static string ToReadable(this long number) =>
            ToReadable((double) number);
        
        public static string ToReadable(this ulong number) =>
            ToReadable((double) number);

        public static string ToReadable(this double number)
        {
            var i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(number) - 2));
            var result = number / i * i;

            return result switch
            {
                >= 1_000_000_000_000 => $"{result / 1_000_000_000_000:0.#}T",
                >= 1_000_000_000 => $"{result / 1_000_000_000:0.#}B",
                >= 1_000_000 => $"{result / 1_000_000:0.#}M",
                >= 1_000 => $"{result / 1_000:0.#}K",
                _ => result.ToString("#,0")
            };
        }
    }
}
