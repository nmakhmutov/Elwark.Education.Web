namespace Education.Web.Client.Features.History.Services;

public sealed record UserActivityOverviewModel(ulong PassedTests, TimeSpan TimeSpent, bool IsBookmarked, bool? IsLiked);
