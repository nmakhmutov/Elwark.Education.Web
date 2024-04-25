namespace Education.Client.Extensions;

public static class Percentage
{
    public static double Calc(double value, double total) =>
        (value / total * 100) switch
        {
            double.NaN => 0,
            double.NegativeInfinity => -100,
            double.PositiveInfinity => 100,
            var x => double.Round(x, 2)
        };
}
