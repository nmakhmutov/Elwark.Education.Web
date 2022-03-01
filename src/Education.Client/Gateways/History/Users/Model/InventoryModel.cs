using Education.Client.Gateways.Models.Inventory;

namespace Education.Client.Gateways.History.Users.Model;

public sealed record InventoryModel(
    uint Capacity,
    uint Fullness,
    DescribedInventoryItemModel[] Items,
    GiftInventoryItemModel[] Gifts
);
