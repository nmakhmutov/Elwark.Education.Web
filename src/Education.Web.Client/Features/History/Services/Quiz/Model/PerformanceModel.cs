namespace Education.Web.Client.Features.History.Services.Quiz.Model;

public sealed record PerformanceModel<T>(T Raw, T Possible, double Scaled);
