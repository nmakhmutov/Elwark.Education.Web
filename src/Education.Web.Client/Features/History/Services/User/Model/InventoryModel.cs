using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record InventoryModel(IReadOnlyDictionary<InternalCurrency, long> Wallet, InventoryModel.BackpackModel Backpack)
{
    public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness);
}