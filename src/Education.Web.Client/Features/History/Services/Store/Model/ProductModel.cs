using Education.Web.Client.Models;
using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.Store.Model;

public sealed record ProductModel(
    uint Id,
    string Title,
    string ImageUrl,
    uint InventoryWeight,
    ProductModel.PriceModel Selling,
    ProductModel.PriceModel Purchasing,
    UserInventoryModel[] Inventories
)
{
    public sealed record PriceModel(InternalMoneyModel Original, InternalMoneyModel Total, uint Discount);
}
