using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record PossessionsModel(
    IReadOnlyDictionary<InternalCurrency, long> Wallet,
    PossessionsModel.BackpackModel Backpack
)
{
    public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness)
    {
        public bool IsFull =>
            Fullness >= Capacity;
    }
}