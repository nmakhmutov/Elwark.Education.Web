using Education.Web.Gateways.Models.Inventory;

namespace Education.Web.Gateways.History.Users.Model;

public sealed record InventoryOverviewModel(uint Capacity, uint Fullness, UserInventoryItemModel[] Items);
