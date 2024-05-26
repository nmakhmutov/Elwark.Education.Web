using Education.Client.Features.History.Clients.User.Model;
using Education.Client.Models;

namespace Education.Client.Features.Customer.Pages.Account;

public sealed record SubjectEnhancedModel(
    string Title,
    string Icon,
    string Gradient,
    SubjectEnhancedModel.SubjectLinks Links,
    UserLevelModel Level,
    BackpackOverviewModel Backpack,
    Dictionary<InternalCurrency, long> Wallet
)
{
    public sealed record SubjectLinks(string Root, string Dashboard, string Wallet, string Backpack);
}
