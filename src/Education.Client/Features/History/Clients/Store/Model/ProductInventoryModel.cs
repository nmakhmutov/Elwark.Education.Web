using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Store.Model;

public sealed record ProductInventoryModel(
    string ProductId,
    uint InventoryId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    PriceModel Selling,
    PriceModel Purchasing,
    CategoryType[] Categories
) : Product(ProductId, Title, Overview, ImageUrl, Weight);
