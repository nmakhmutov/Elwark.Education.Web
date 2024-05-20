using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models;

namespace Education.Client.Features.Customer.Pages.Account;

public sealed record SubjectEnhancedModel(
    string Title,
    string SubjectHref,
    string ProfileHref,
    string Icon,
    string Gradient,
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet
);
