namespace Education.Client.Gateways.History;

public sealed record UserActivitySummary(ulong PassedTests, TimeSpan TimeSpent, bool IsFavorite, bool? IsLiked);
