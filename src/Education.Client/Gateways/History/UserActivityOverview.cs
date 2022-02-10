namespace Education.Client.Gateways.History;

public sealed record UserActivityOverview(ulong PassedTests, TimeSpan TimeSpent, bool IsFavorite, bool? IsLiked);
