using Education.Client.Gateways.Models.Inventory;

namespace Education.Client.Gateways.History.Users.Model;

public sealed record InventoryOverviewModel(uint Capacity, uint Fullness, DescribedInventoryItemModel[] Items);
