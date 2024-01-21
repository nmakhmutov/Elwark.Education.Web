using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Store.Model;

public sealed record ProductBundleModel(
    string ProductId,
    string Title,
    string Overview,
    string ImageUrl,
    uint Weight,
    PriceModel Price,
    UserInventoryModel[] Inventories
) : Product(ProductId, Title, Overview, ImageUrl, Weight);