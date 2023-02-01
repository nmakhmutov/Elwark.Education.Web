namespace Education.Web.Client.Models.Inventory;

public sealed record UserInventoryModel(
    uint Id,
    uint Quantity,
    string Title,
    string Overview,
    string IconUrl,
    InventoryCategoryModel Category
);
