namespace Education.Client.Gateways.History.User;

public sealed record InventoryOverview(uint Capacity, uint Fullness, IEnumerable<UserInventoryItem> Items);
