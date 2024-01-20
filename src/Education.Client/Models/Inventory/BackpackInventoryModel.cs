namespace Education.Client.Models.Inventory;

public sealed record BackpackInventoryModel(
    uint InventoryId,
    string ProductId,
    string Title,
    string Overview,
    string IconUrl,
    uint Quantity,
    CategoryType Category
) : InventoryModel(InventoryId, Title, Overview, IconUrl);
