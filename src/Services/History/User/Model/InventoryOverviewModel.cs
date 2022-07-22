using Education.Web.Services.Model.Inventory;

namespace Education.Web.Services.History.User.Model;

public sealed record InventoryOverviewModel(uint Capacity, uint Fullness, UserInventoryItemModel[] Items);
