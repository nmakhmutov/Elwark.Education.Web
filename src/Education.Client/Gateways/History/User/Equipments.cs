namespace Education.Client.Gateways.History.User;

public sealed record Equipments(uint Capacity, uint Fullness, IEnumerable<UserEquipment> Items);
