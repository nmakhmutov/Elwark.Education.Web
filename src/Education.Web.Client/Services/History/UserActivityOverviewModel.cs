namespace Education.Web.Client.Services.History;

public sealed record UserActivityOverviewModel(ulong PassedTests, TimeSpan TimeSpent, bool IsBookmarked, bool? IsLiked);
