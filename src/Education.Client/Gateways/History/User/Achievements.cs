namespace Education.Client.Gateways.History.User;

public sealed record Achievements(uint Total, uint Completed, Achievement[] Items);
