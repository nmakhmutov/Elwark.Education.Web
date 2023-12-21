using Education.Client.Models;

namespace Education.Client.Features.History.Clients.User.Model;

public sealed record ProfileModel(
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet
);
