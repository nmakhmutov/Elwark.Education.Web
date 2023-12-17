using Education.Web.Client.Models;

namespace Education.Web.Client.Features.History.Clients.User.Model;

public sealed record ProfileModel(
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet
);
