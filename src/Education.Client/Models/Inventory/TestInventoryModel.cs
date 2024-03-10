namespace Education.Client.Models.Inventory;

public sealed record TestInventoryModel(
    uint InventoryId,
    string Title,
    string Overview,
    string IconUrl,
    uint Quantity,
    bool IsInteractive
) : InventoryModel(InventoryId, Title, Overview, IconUrl);
