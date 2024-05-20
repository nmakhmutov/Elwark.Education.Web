using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models;

namespace Education.Client.Features.Customer.Services.Account.Model;

public sealed record SubjectModel(
    string Name,
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet
);
