using Education.Web.Gateways.Models.Inventory;

namespace Education.Web.Gateways.History.Users.Model;

public sealed record InventoryModel(
    uint Capacity,
    uint Fullness,
    DescribedInventoryItemModel[] Items,
    GiftInventoryItemModel[] Gifts
);
