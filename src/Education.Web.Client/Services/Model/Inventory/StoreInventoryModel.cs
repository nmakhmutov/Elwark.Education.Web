namespace Education.Web.Client.Services.Model.Inventory;

public sealed record StoreInventoryModel(
    uint Id,
    uint Count,
    string Title,
    string Overview,
    string IconUrl,
    IInternalMoney OriginalPrice,
    IInternalMoney TotalPrice,
    InventoryCategoryModel Category
);
