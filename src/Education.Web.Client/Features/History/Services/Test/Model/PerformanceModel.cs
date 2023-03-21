namespace Education.Web.Client.Features.History.Services.Test.Model;

public sealed record PerformanceModel<T>(T Raw, T Possible, double Scaled);
