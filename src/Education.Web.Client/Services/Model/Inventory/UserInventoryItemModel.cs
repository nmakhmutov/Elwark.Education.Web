namespace Education.Web.Client.Services.Model.Inventory;

public sealed record UserInventoryItemModel(
    uint Id,
    uint Count,
    string Title,
    string Overview,
    string IconUrl,
    InventoryCategoryModel Category
);
