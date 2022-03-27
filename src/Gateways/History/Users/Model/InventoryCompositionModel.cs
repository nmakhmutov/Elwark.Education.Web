using Education.Web.Gateways.Models.Inventory;
using Education.Web.Gateways.Models.User;

namespace Education.Web.Gateways.History.Users.Model;

public sealed record InventoryCompositionModel(
    SilverWalletModel Silver,
    InventoryOverviewModel Inventory,
    GiftInventoryItemModel[] Gifts
);
