namespace Education.Web.Client.Models.Statistics;

public sealed record DeltaModel<T>(T Current, double Difference);
