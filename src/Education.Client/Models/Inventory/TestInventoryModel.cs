namespace Education.Client.Models.Inventory;

public sealed record TestInventoryModel(
    uint Id,
    uint Quantity,
    string Title,
    string Overview,
    string IconUrl,
    bool IsInteractive
);
