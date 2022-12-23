namespace Education.Web.Client.Services.Model.Inventory;

public sealed record UserInventoryModel(
    uint Id,
    uint Count,
    string Title,
    string Overview,
    string IconUrl,
    InventoryCategoryModel Category
);