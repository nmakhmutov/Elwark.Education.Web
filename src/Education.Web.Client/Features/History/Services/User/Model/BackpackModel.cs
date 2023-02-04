using Education.Web.Client.Models.Inventory;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness, UserInventoryModel[] Items);
