namespace Education.Web.Client.Services.Model.Inventory;

public sealed record UserInventoryModel(
    uint Id,
    uint Quantity,
    string Title,
    string Overview,
    string IconUrl,
    InventoryCategoryModel Category
);
