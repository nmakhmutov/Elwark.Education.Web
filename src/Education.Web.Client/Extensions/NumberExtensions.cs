using System.Diagnostics.CodeAnalysis;

namespace Education.Web.Client.Extensions;

public static class NumberExtensions
{
    private static readonly char[] Prefixes = { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };

    public static string ToMetric(this int input,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)]
        string? format = null) =>
        ToMetric((double)input, format);

    public static string ToMetric(this long input,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)]
        string? format = null) =>
        ToMetric((double)input, format);

    public static string ToMetric(this uint input,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null) =>
        ToMetric((double)input, format);

    public static string ToMetric(this ulong input,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null) =>
        ToMetric((double)input, format);

    public static string ToMetric(this double input,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)]
        string? format = null)
    {
        var exponent = (int)Math.Floor(Math.Log10(Math.Abs(input)) / 3);
        if (exponent <= 0)
            return Math.Round(input, 1).ToString(format);

        var number = input * Math.Pow(1000, -exponent);
        var symbol = Prefixes[exponent - 1];

        return $"{Math.Round(number, 1).ToString(format)}{symbol}";
    }
}
