using Education.Client.Features.History.Clients;
using Education.Client.Features.History.Clients.User.Model;

namespace Education.Client.Features.Customer.Services.Account.Model;

public sealed record SubjectModel(
    string Name,
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<GameCurrency, long> Wallet
);
