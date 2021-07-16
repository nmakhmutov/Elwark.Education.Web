namespace Education.Client.Gateways.Models.Statistics
{
    public sealed record Contrast<T>(T Current, double Difference);
}
