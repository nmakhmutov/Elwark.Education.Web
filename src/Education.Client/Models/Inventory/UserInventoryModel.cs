namespace Education.Client.Models.Inventory;

public sealed record UserInventoryModel(
    uint InventoryId,
    string Title,
    string Overview,
    string IconUrl,
    uint Quantity,
    CategoryType Category
) : InventoryModel(InventoryId, Title, Overview, IconUrl);
