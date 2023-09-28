using System.Collections.ObjectModel;
using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Services.User.Model;

public sealed record PossessionsModel(
    IReadOnlyDictionary<InternalCurrency, long> Wallet,
    PossessionsModel.BackpackModel Backpack
)
{
    public static readonly PossessionsModel Empty =
        new(ReadOnlyDictionary<InternalCurrency, long>.Empty, new BackpackModel(0, 0, 0));

    public sealed record BackpackModel(uint Capacity, uint Fullness, uint Emptiness);
}
