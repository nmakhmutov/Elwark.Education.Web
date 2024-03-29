namespace Education.Client.Models.Inventory;

public sealed record BackpackInventoryModel(
    uint InventoryId,
    string ProductId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Quantity,
    CategoryType[] Categories
) : InventoryModel(InventoryId, Title, Overview, ImageUrl);
