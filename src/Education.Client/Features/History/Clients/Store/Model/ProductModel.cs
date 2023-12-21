using Education.Client.Models;
using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.Store.Model;

public abstract record Product(string Id, string Title, uint Weight)
{
    public sealed record InventoryModel(
        string Id,
        uint InventoryId,
        string Title,
        string ImageUrl,
        string Overview,
        CategoryType Category,
        uint Weight,
        PriceModel Selling,
        PriceModel Purchasing
    ) : Product(Id, Title, Weight);

    public sealed record BundleModel(
        string Id,
        string Title,
        string Overview,
        string ImageUrl,
        uint Weight,
        PriceModel Price,
        UserInventoryModel[] Inventories
    ) : Product(Id, Title, Weight);

    public sealed record PriceModel(InternalMoneyModel Original, InternalMoneyModel Total, uint Discount);
}
