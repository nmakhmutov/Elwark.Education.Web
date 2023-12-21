namespace Education.Client.Models.Statistics;

public sealed record DeltaModel<T>(T Current, double Difference);
