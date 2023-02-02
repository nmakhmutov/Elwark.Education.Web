namespace Education.Web.Client.Extensions;

public static class NumberExtensions
{
    private static readonly char[] Prefixes = { ' ', 'k', 'M', 'B', 'T', 'Q' };

    public static string ToMetric(this int number) =>
        ToMetric((double)number);

    public static string ToMetric(this long number) =>
        ToMetric((double)number);

    public static string ToMetric(this uint number) =>
        ToMetric((double)number);

    public static string ToMetric(this ulong number) =>
        ToMetric((double)number);

    public static string ToMetric(this double number)
    {
        var degree = (int)Math.Floor(Math.Log10(Math.Abs(number)) / 3);
        var scaled = number * Math.Pow(1000, -degree);
        var prefix = Prefixes[int.Max(0, degree)];

        return $"{Math.Round(scaled, 1)}{prefix}";
    }
}
