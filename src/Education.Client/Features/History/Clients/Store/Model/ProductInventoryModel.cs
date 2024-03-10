using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Store.Model;

public sealed record ProductInventoryModel(
    string ProductId,
    uint InventoryId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    CategoryType Category,
    PriceModel Selling,
    PriceModel Purchasing
) : Product(ProductId, Title, Overview, ImageUrl, Weight);
