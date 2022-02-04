namespace Education.Client.Gateways.History.User;

public sealed record InventorySummary(uint Capacity, uint Fullness, IEnumerable<UserEquipment> Items);
