namespace Education.Client.Gateways.History.User;

public sealed record CategorizedAchievements(string Category, uint Total, uint Completed, Achievement[] Items);
