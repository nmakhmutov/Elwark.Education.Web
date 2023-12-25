namespace Education.Client.Models.Test;

public sealed record PerformanceModel<T>(T UserPoints, T TotalPoints, double Ratio);
