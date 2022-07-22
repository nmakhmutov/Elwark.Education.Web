namespace Education.Web.Services.Model.Statistics;

public sealed record ContrastModel<T>(T Current, double Difference);
