using Education.Web.Client.Services.Model;
using Education.Web.Client.Services.Model.Inventory;

namespace Education.Web.Client.Services.History.Store.Model;

public sealed record StoreBundleModel(
    uint Id,
    string Title,
    string Overview,
    string ImageUrl,
    IInternalMoney Price,
    UserInventoryModel[] Inventories
);