using Education.Web.Client.Services.Model.Inventory;

namespace Education.Web.Client.Services.History.User.Model;

public sealed record InventoryOverviewModel(uint Capacity, uint Fullness, UserInventoryItemModel[] Items);
