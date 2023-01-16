namespace Education.Web.Client.Extensions;

public static class NumberExtensions
{
    private static readonly char[] Prefixes = { ' ', 'K', 'M', 'B', 'T', 'Q' };

    public static string ToReadable(this int number) =>
        ToReadable((double)number);

    public static string ToReadable(this long number) =>
        ToReadable((double)number);

    public static string ToReadable(this uint number) =>
        ToReadable((double)number);

    public static string ToReadable(this ulong number) =>
        ToReadable((double)number);

    public static string ToReadable(this double number)
    {
        var degree = (int)Math.Floor(Math.Log10(Math.Abs(number)) / 3);
        var scaled = number * Math.Pow(1000, -degree);
        var prefix = Prefixes[int.Max(0, degree)];

        return $"{Math.Round(scaled, 1)}{prefix}";
    }
}
