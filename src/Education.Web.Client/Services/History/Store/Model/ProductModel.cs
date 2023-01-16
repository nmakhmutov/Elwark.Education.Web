using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Inventory;

namespace Education.Web.Client.Services.History.Store.Model;

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
    public sealed record PriceModel(IInternalMoney Original, IInternalMoney Total);    
}