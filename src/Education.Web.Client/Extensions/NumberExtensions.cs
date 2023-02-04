namespace Education.Web.Client.Extensions;

public static class NumberExtensions
{
    private static readonly char[] Prefixes = { 'k', 'M', 'G', 'T', 'P', 'E', 'Z', 'Y' };

    public static string ToMetric(this int input) =>
        ToMetric((double)input);

    public static string ToMetric(this long input) =>
        ToMetric((double)input);

    public static string ToMetric(this uint input) =>
        ToMetric((double)input);

    public static string ToMetric(this ulong input) =>
        ToMetric((double)input);

    public static string ToMetric(this double input)
    {
        var exponent = (int)Math.Floor(Math.Log10(Math.Abs(input)) / 3);
        if (exponent <= 0)
            return Math.Round(input, 1).ToString("G");

        var number = input * Math.Pow(1000, -exponent);
        var symbol = Prefixes[exponent - 1];

        return $"{Math.Round(number, 1):G}{symbol}";
    }
}
