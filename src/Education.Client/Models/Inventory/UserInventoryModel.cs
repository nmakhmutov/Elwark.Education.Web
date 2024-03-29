namespace Education.Client.Models.Inventory;

public sealed record UserInventoryModel(
    uint InventoryId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Quantity,
    CategoryType[] Categories
) : InventoryModel(InventoryId, Title, Overview, ImageUrl);
