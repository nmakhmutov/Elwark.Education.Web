using Education.Web.Client.Models;
using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.Store.Model;

public abstract record Product(string Id, string Title, uint Weight)
{
    public sealed record InventoryModel(
        string Id,
        uint InventoryId,
        string Title,
        string IconUrl,
        string Overview,
        InventoryCategoryModel Category,
        uint Weight,
        PriceModel Selling,
        PriceModel Purchasing
    ) : Product(Id, Title, Weight);

    public sealed record BundleModel(
        string Id,
        string Title,
        string ImageUrl,
        uint Weight,
        PriceModel Price,
        UserInventoryModel[] Inventories
    ) : Product(Id, Title, Weight);

    public sealed record PriceModel(InternalMoneyModel Original, InternalMoneyModel Total, uint Discount);
}
