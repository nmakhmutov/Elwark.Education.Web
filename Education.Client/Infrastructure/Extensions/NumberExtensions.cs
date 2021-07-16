using System;

namespace Education.Client.Infrastructure.Extensions
{
    public static class NumberExtensions
    {
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
            var value = Math.Abs(number);
            var i = (long)Math.Pow(10, (int)Math.Max(0, Math.Log10(value) - 2));
            var result = value / i * i;

            var formatted = Math.Abs(result) switch
            {
                >= 1_000_000_000_000 => $"{result / 1_000_000_000_000:0.#}T",
                >= 1_000_000_000 => $"{result / 1_000_000_000:0.#}B",
                >= 1_000_000 => $"{result / 1_000_000:0.#}M",
                >= 1_000 => $"{result / 1_000:0.#}K",
                _ => result.ToString("#,0")
            };
            
            return $"{(number < 0 ? "-" : "")}{formatted}";
        }
    }
}
