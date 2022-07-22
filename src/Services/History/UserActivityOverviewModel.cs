namespace Education.Web.Services.History;

public sealed record UserActivityOverviewModel(ulong PassedTests, TimeSpan TimeSpent, bool IsFavorite, bool? IsLiked);
