namespace Education.Client.Gateways.History.User;

public sealed record Inventory(
    uint Capacity,
    uint Fullness,
    IEnumerable<UserInventoryItem> Items,
    IEnumerable<FreeInventoryItem> Gifts
);
