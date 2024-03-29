using Education.Client.Models.Inventory;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness, BackpackInventoryModel[] Items);
