using Education.Web.Client.Services.Model.Inventory;

namespace Education.Web.Client.Services.History.Store.Model;

public sealed record StorefrontModel(
    StoreBundleModel[] Bundles,
    StoreInventoryModel[] Inventories
);
