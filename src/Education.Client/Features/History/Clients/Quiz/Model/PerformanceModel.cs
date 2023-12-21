namespace Education.Client.Features.History.Clients.Quiz.Model;

public sealed record PerformanceModel<T>(T Raw, T Possible, double Scaled);
