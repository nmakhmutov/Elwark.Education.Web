namespace Education.Client.Gateways.Models.Statistics;

public sealed record ContrastModel<T>(T Current, double Difference);
